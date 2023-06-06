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
	/// This class is the base class for any <see cref="Vw_RecordingListProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class Vw_RecordingListProviderBaseCore : EntityViewProviderBase<Vw_RecordingList>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;Vw_RecordingList&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;Vw_RecordingList&gt;"/></returns>
		protected static VList&lt;Vw_RecordingList&gt; Fill(DataSet dataSet, VList<Vw_RecordingList> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<Vw_RecordingList>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;Vw_RecordingList&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<Vw_RecordingList>"/></returns>
		protected static VList&lt;Vw_RecordingList&gt; Fill(DataTable dataTable, VList<Vw_RecordingList> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					Vw_RecordingList c = new Vw_RecordingList();
					c.Id = (Convert.IsDBNull(row["ID"]))?(int)0:(System.Int32)row["ID"];
					c.WholesalerId = (Convert.IsDBNull(row["WholesalerID"]))?string.Empty:(System.String)row["WholesalerID"];
					c.BridgeId = (Convert.IsDBNull(row["BridgeID"]))?(int)0:(System.Int32?)row["BridgeID"];
					c.RecordingStartTime = (Convert.IsDBNull(row["RecordingStartTime"]))?DateTime.MinValue:(System.DateTime?)row["RecordingStartTime"];
					c.RecordingEndTime = (Convert.IsDBNull(row["RecordingEndTime"]))?DateTime.MinValue:(System.DateTime?)row["RecordingEndTime"];
					c.ModeratorCode = (Convert.IsDBNull(row["ModeratorCode"]))?string.Empty:(System.String)row["ModeratorCode"];
					c.PassCode = (Convert.IsDBNull(row["PassCode"]))?string.Empty:(System.String)row["PassCode"];
					c.PriCustomerNumber = (Convert.IsDBNull(row["PriCustomerNumber"]))?string.Empty:(System.String)row["PriCustomerNumber"];
					c.SecCustomerNumber = (Convert.IsDBNull(row["SecCustomerNumber"]))?string.Empty:(System.String)row["SecCustomerNumber"];
					c.RecordingDirectory = (Convert.IsDBNull(row["RecordingDirectory"]))?string.Empty:(System.String)row["RecordingDirectory"];
					c.UniqueConferenceId = (Convert.IsDBNull(row["UniqueConferenceID"]))?string.Empty:(System.String)row["UniqueConferenceID"];
					c.ReplayCode = (Convert.IsDBNull(row["ReplayCode"]))?string.Empty:(System.String)row["ReplayCode"];
					c.CreatedDate = (Convert.IsDBNull(row["CreatedDate"]))?DateTime.MinValue:(System.DateTime?)row["CreatedDate"];
					c.ProcessFlag = (Convert.IsDBNull(row["ProcessFlag"]))?string.Empty:(System.String)row["ProcessFlag"];
					c.EmailSent = (Convert.IsDBNull(row["EmailSent"]))?false:(System.Boolean?)row["EmailSent"];
					c.RpFileNumber = (Convert.IsDBNull(row["RPFileNumber"]))?string.Empty:(System.String)row["RPFileNumber"];
					c.ModeratorId = (Convert.IsDBNull(row["ModeratorID"]))?(int)0:(System.Int32?)row["ModeratorID"];
					c.Notes = (Convert.IsDBNull(row["Notes"]))?string.Empty:(System.String)row["Notes"];
					c.Mp3Flag = (Convert.IsDBNull(row["Mp3Flag"]))?string.Empty:(System.String)row["Mp3Flag"];
					c.Mp3SizeInKb = (Convert.IsDBNull(row["Mp3SizeInKB"]))?(int)0:(System.Int32?)row["Mp3SizeInKB"];
					c.Enabled = (Convert.IsDBNull(row["Enabled"]))?false:(System.Boolean?)row["Enabled"];
					c.StorageDuration = (Convert.IsDBNull(row["StorageDuration"]))?(short)0:(System.Int16?)row["StorageDuration"];
					c.BillingDuration = (Convert.IsDBNull(row["BillingDuration"]))?(short)0:(System.Int16?)row["BillingDuration"];
					c.BillingId = (Convert.IsDBNull(row["BillingID"]))?string.Empty:(System.String)row["BillingID"];
					c.DurationSec = (Convert.IsDBNull(row["DurationSec"]))?(int)0:(System.Int32?)row["DurationSec"];
					c.AuxiliaryConferenceId = (Convert.IsDBNull(row["AuxiliaryConferenceID"]))?string.Empty:(System.String)row["AuxiliaryConferenceID"];
					c.MediaType = (Convert.IsDBNull(row["MediaType"]))?string.Empty:(System.String)row["MediaType"];
					c.HostedLinkExpiryDate = (Convert.IsDBNull(row["HostedLinkExpiryDate"]))?DateTime.MinValue:(System.DateTime?)row["HostedLinkExpiryDate"];
					c.ConferenceName = (Convert.IsDBNull(row["ConferenceName"]))?string.Empty:(System.String)row["ConferenceName"];
					c.Username = (Convert.IsDBNull(row["Username"]))?string.Empty:(System.String)row["Username"];
					c.DisplayName = (Convert.IsDBNull(row["DisplayName"]))?string.Empty:(System.String)row["DisplayName"];
					c.ExtendRecordingDate = (Convert.IsDBNull(row["ExtendRecordingDate"]))?DateTime.MinValue:(System.DateTime?)row["ExtendRecordingDate"];
					c.UserId = (Convert.IsDBNull(row["UserID"]))?(int)0:(System.Int32)row["UserID"];
					c.HostedLinkType = (Convert.IsDBNull(row["HostedLinkType"]))?string.Empty:(System.String)row["HostedLinkType"];
					c.HostedLinkUrl = (Convert.IsDBNull(row["HostedLinkURL"]))?string.Empty:(System.String)row["HostedLinkURL"];
					c.RecordingGuid = (Convert.IsDBNull(row["RecordingGuid"]))?string.Empty:(System.String)row["RecordingGuid"];
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
		/// Fill an <see cref="VList&lt;Vw_RecordingList&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;Vw_RecordingList&gt;"/></returns>
		protected VList<Vw_RecordingList> Fill(IDataReader reader, VList<Vw_RecordingList> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					Vw_RecordingList entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<Vw_RecordingList>("Vw_RecordingList",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new Vw_RecordingList();
					}
					
					entity.SuppressEntityEvents = true;

					entity.Id = (System.Int32)reader[((int)Vw_RecordingListColumn.Id)];
					//entity.Id = (Convert.IsDBNull(reader["ID"]))?(int)0:(System.Int32)reader["ID"];
					entity.WholesalerId = (System.String)reader[((int)Vw_RecordingListColumn.WholesalerId)];
					//entity.WholesalerId = (Convert.IsDBNull(reader["WholesalerID"]))?string.Empty:(System.String)reader["WholesalerID"];
					entity.BridgeId = (reader.IsDBNull(((int)Vw_RecordingListColumn.BridgeId)))?null:(System.Int32?)reader[((int)Vw_RecordingListColumn.BridgeId)];
					//entity.BridgeId = (Convert.IsDBNull(reader["BridgeID"]))?(int)0:(System.Int32?)reader["BridgeID"];
					entity.RecordingStartTime = (reader.IsDBNull(((int)Vw_RecordingListColumn.RecordingStartTime)))?null:(System.DateTime?)reader[((int)Vw_RecordingListColumn.RecordingStartTime)];
					//entity.RecordingStartTime = (Convert.IsDBNull(reader["RecordingStartTime"]))?DateTime.MinValue:(System.DateTime?)reader["RecordingStartTime"];
					entity.RecordingEndTime = (reader.IsDBNull(((int)Vw_RecordingListColumn.RecordingEndTime)))?null:(System.DateTime?)reader[((int)Vw_RecordingListColumn.RecordingEndTime)];
					//entity.RecordingEndTime = (Convert.IsDBNull(reader["RecordingEndTime"]))?DateTime.MinValue:(System.DateTime?)reader["RecordingEndTime"];
					entity.ModeratorCode = (reader.IsDBNull(((int)Vw_RecordingListColumn.ModeratorCode)))?null:(System.String)reader[((int)Vw_RecordingListColumn.ModeratorCode)];
					//entity.ModeratorCode = (Convert.IsDBNull(reader["ModeratorCode"]))?string.Empty:(System.String)reader["ModeratorCode"];
					entity.PassCode = (reader.IsDBNull(((int)Vw_RecordingListColumn.PassCode)))?null:(System.String)reader[((int)Vw_RecordingListColumn.PassCode)];
					//entity.PassCode = (Convert.IsDBNull(reader["PassCode"]))?string.Empty:(System.String)reader["PassCode"];
					entity.PriCustomerNumber = (reader.IsDBNull(((int)Vw_RecordingListColumn.PriCustomerNumber)))?null:(System.String)reader[((int)Vw_RecordingListColumn.PriCustomerNumber)];
					//entity.PriCustomerNumber = (Convert.IsDBNull(reader["PriCustomerNumber"]))?string.Empty:(System.String)reader["PriCustomerNumber"];
					entity.SecCustomerNumber = (reader.IsDBNull(((int)Vw_RecordingListColumn.SecCustomerNumber)))?null:(System.String)reader[((int)Vw_RecordingListColumn.SecCustomerNumber)];
					//entity.SecCustomerNumber = (Convert.IsDBNull(reader["SecCustomerNumber"]))?string.Empty:(System.String)reader["SecCustomerNumber"];
					entity.RecordingDirectory = (reader.IsDBNull(((int)Vw_RecordingListColumn.RecordingDirectory)))?null:(System.String)reader[((int)Vw_RecordingListColumn.RecordingDirectory)];
					//entity.RecordingDirectory = (Convert.IsDBNull(reader["RecordingDirectory"]))?string.Empty:(System.String)reader["RecordingDirectory"];
					entity.UniqueConferenceId = (reader.IsDBNull(((int)Vw_RecordingListColumn.UniqueConferenceId)))?null:(System.String)reader[((int)Vw_RecordingListColumn.UniqueConferenceId)];
					//entity.UniqueConferenceId = (Convert.IsDBNull(reader["UniqueConferenceID"]))?string.Empty:(System.String)reader["UniqueConferenceID"];
					entity.ReplayCode = (reader.IsDBNull(((int)Vw_RecordingListColumn.ReplayCode)))?null:(System.String)reader[((int)Vw_RecordingListColumn.ReplayCode)];
					//entity.ReplayCode = (Convert.IsDBNull(reader["ReplayCode"]))?string.Empty:(System.String)reader["ReplayCode"];
					entity.CreatedDate = (reader.IsDBNull(((int)Vw_RecordingListColumn.CreatedDate)))?null:(System.DateTime?)reader[((int)Vw_RecordingListColumn.CreatedDate)];
					//entity.CreatedDate = (Convert.IsDBNull(reader["CreatedDate"]))?DateTime.MinValue:(System.DateTime?)reader["CreatedDate"];
					entity.ProcessFlag = (reader.IsDBNull(((int)Vw_RecordingListColumn.ProcessFlag)))?null:(System.String)reader[((int)Vw_RecordingListColumn.ProcessFlag)];
					//entity.ProcessFlag = (Convert.IsDBNull(reader["ProcessFlag"]))?string.Empty:(System.String)reader["ProcessFlag"];
					entity.EmailSent = (reader.IsDBNull(((int)Vw_RecordingListColumn.EmailSent)))?null:(System.Boolean?)reader[((int)Vw_RecordingListColumn.EmailSent)];
					//entity.EmailSent = (Convert.IsDBNull(reader["EmailSent"]))?false:(System.Boolean?)reader["EmailSent"];
					entity.RpFileNumber = (reader.IsDBNull(((int)Vw_RecordingListColumn.RpFileNumber)))?null:(System.String)reader[((int)Vw_RecordingListColumn.RpFileNumber)];
					//entity.RpFileNumber = (Convert.IsDBNull(reader["RPFileNumber"]))?string.Empty:(System.String)reader["RPFileNumber"];
					entity.ModeratorId = (reader.IsDBNull(((int)Vw_RecordingListColumn.ModeratorId)))?null:(System.Int32?)reader[((int)Vw_RecordingListColumn.ModeratorId)];
					//entity.ModeratorId = (Convert.IsDBNull(reader["ModeratorID"]))?(int)0:(System.Int32?)reader["ModeratorID"];
					entity.Notes = (reader.IsDBNull(((int)Vw_RecordingListColumn.Notes)))?null:(System.String)reader[((int)Vw_RecordingListColumn.Notes)];
					//entity.Notes = (Convert.IsDBNull(reader["Notes"]))?string.Empty:(System.String)reader["Notes"];
					entity.Mp3Flag = (reader.IsDBNull(((int)Vw_RecordingListColumn.Mp3Flag)))?null:(System.String)reader[((int)Vw_RecordingListColumn.Mp3Flag)];
					//entity.Mp3Flag = (Convert.IsDBNull(reader["Mp3Flag"]))?string.Empty:(System.String)reader["Mp3Flag"];
					entity.Mp3SizeInKb = (reader.IsDBNull(((int)Vw_RecordingListColumn.Mp3SizeInKb)))?null:(System.Int32?)reader[((int)Vw_RecordingListColumn.Mp3SizeInKb)];
					//entity.Mp3SizeInKb = (Convert.IsDBNull(reader["Mp3SizeInKB"]))?(int)0:(System.Int32?)reader["Mp3SizeInKB"];
					entity.Enabled = (reader.IsDBNull(((int)Vw_RecordingListColumn.Enabled)))?null:(System.Boolean?)reader[((int)Vw_RecordingListColumn.Enabled)];
					//entity.Enabled = (Convert.IsDBNull(reader["Enabled"]))?false:(System.Boolean?)reader["Enabled"];
					entity.StorageDuration = (reader.IsDBNull(((int)Vw_RecordingListColumn.StorageDuration)))?null:(System.Int16?)reader[((int)Vw_RecordingListColumn.StorageDuration)];
					//entity.StorageDuration = (Convert.IsDBNull(reader["StorageDuration"]))?(short)0:(System.Int16?)reader["StorageDuration"];
					entity.BillingDuration = (reader.IsDBNull(((int)Vw_RecordingListColumn.BillingDuration)))?null:(System.Int16?)reader[((int)Vw_RecordingListColumn.BillingDuration)];
					//entity.BillingDuration = (Convert.IsDBNull(reader["BillingDuration"]))?(short)0:(System.Int16?)reader["BillingDuration"];
					entity.BillingId = (reader.IsDBNull(((int)Vw_RecordingListColumn.BillingId)))?null:(System.String)reader[((int)Vw_RecordingListColumn.BillingId)];
					//entity.BillingId = (Convert.IsDBNull(reader["BillingID"]))?string.Empty:(System.String)reader["BillingID"];
					entity.DurationSec = (reader.IsDBNull(((int)Vw_RecordingListColumn.DurationSec)))?null:(System.Int32?)reader[((int)Vw_RecordingListColumn.DurationSec)];
					//entity.DurationSec = (Convert.IsDBNull(reader["DurationSec"]))?(int)0:(System.Int32?)reader["DurationSec"];
					entity.AuxiliaryConferenceId = (reader.IsDBNull(((int)Vw_RecordingListColumn.AuxiliaryConferenceId)))?null:(System.String)reader[((int)Vw_RecordingListColumn.AuxiliaryConferenceId)];
					//entity.AuxiliaryConferenceId = (Convert.IsDBNull(reader["AuxiliaryConferenceID"]))?string.Empty:(System.String)reader["AuxiliaryConferenceID"];
					entity.MediaType = (reader.IsDBNull(((int)Vw_RecordingListColumn.MediaType)))?null:(System.String)reader[((int)Vw_RecordingListColumn.MediaType)];
					//entity.MediaType = (Convert.IsDBNull(reader["MediaType"]))?string.Empty:(System.String)reader["MediaType"];
					entity.HostedLinkExpiryDate = (reader.IsDBNull(((int)Vw_RecordingListColumn.HostedLinkExpiryDate)))?null:(System.DateTime?)reader[((int)Vw_RecordingListColumn.HostedLinkExpiryDate)];
					//entity.HostedLinkExpiryDate = (Convert.IsDBNull(reader["HostedLinkExpiryDate"]))?DateTime.MinValue:(System.DateTime?)reader["HostedLinkExpiryDate"];
					entity.ConferenceName = (reader.IsDBNull(((int)Vw_RecordingListColumn.ConferenceName)))?null:(System.String)reader[((int)Vw_RecordingListColumn.ConferenceName)];
					//entity.ConferenceName = (Convert.IsDBNull(reader["ConferenceName"]))?string.Empty:(System.String)reader["ConferenceName"];
					entity.Username = (System.String)reader[((int)Vw_RecordingListColumn.Username)];
					//entity.Username = (Convert.IsDBNull(reader["Username"]))?string.Empty:(System.String)reader["Username"];
					entity.DisplayName = (System.String)reader[((int)Vw_RecordingListColumn.DisplayName)];
					//entity.DisplayName = (Convert.IsDBNull(reader["DisplayName"]))?string.Empty:(System.String)reader["DisplayName"];
					entity.ExtendRecordingDate = (reader.IsDBNull(((int)Vw_RecordingListColumn.ExtendRecordingDate)))?null:(System.DateTime?)reader[((int)Vw_RecordingListColumn.ExtendRecordingDate)];
					//entity.ExtendRecordingDate = (Convert.IsDBNull(reader["ExtendRecordingDate"]))?DateTime.MinValue:(System.DateTime?)reader["ExtendRecordingDate"];
					entity.UserId = (System.Int32)reader[((int)Vw_RecordingListColumn.UserId)];
					//entity.UserId = (Convert.IsDBNull(reader["UserID"]))?(int)0:(System.Int32)reader["UserID"];
					entity.HostedLinkType = (reader.IsDBNull(((int)Vw_RecordingListColumn.HostedLinkType)))?null:(System.String)reader[((int)Vw_RecordingListColumn.HostedLinkType)];
					//entity.HostedLinkType = (Convert.IsDBNull(reader["HostedLinkType"]))?string.Empty:(System.String)reader["HostedLinkType"];
					entity.HostedLinkUrl = (reader.IsDBNull(((int)Vw_RecordingListColumn.HostedLinkUrl)))?null:(System.String)reader[((int)Vw_RecordingListColumn.HostedLinkUrl)];
					//entity.HostedLinkUrl = (Convert.IsDBNull(reader["HostedLinkURL"]))?string.Empty:(System.String)reader["HostedLinkURL"];
					entity.RecordingGuid = (reader.IsDBNull(((int)Vw_RecordingListColumn.RecordingGuid)))?null:(System.String)reader[((int)Vw_RecordingListColumn.RecordingGuid)];
					//entity.RecordingGuid = (Convert.IsDBNull(reader["RecordingGuid"]))?string.Empty:(System.String)reader["RecordingGuid"];
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
		/// Refreshes the <see cref="Vw_RecordingList"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Vw_RecordingList"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, Vw_RecordingList entity)
		{
			reader.Read();
			entity.Id = (System.Int32)reader[((int)Vw_RecordingListColumn.Id)];
			//entity.Id = (Convert.IsDBNull(reader["ID"]))?(int)0:(System.Int32)reader["ID"];
			entity.WholesalerId = (System.String)reader[((int)Vw_RecordingListColumn.WholesalerId)];
			//entity.WholesalerId = (Convert.IsDBNull(reader["WholesalerID"]))?string.Empty:(System.String)reader["WholesalerID"];
			entity.BridgeId = (reader.IsDBNull(((int)Vw_RecordingListColumn.BridgeId)))?null:(System.Int32?)reader[((int)Vw_RecordingListColumn.BridgeId)];
			//entity.BridgeId = (Convert.IsDBNull(reader["BridgeID"]))?(int)0:(System.Int32?)reader["BridgeID"];
			entity.RecordingStartTime = (reader.IsDBNull(((int)Vw_RecordingListColumn.RecordingStartTime)))?null:(System.DateTime?)reader[((int)Vw_RecordingListColumn.RecordingStartTime)];
			//entity.RecordingStartTime = (Convert.IsDBNull(reader["RecordingStartTime"]))?DateTime.MinValue:(System.DateTime?)reader["RecordingStartTime"];
			entity.RecordingEndTime = (reader.IsDBNull(((int)Vw_RecordingListColumn.RecordingEndTime)))?null:(System.DateTime?)reader[((int)Vw_RecordingListColumn.RecordingEndTime)];
			//entity.RecordingEndTime = (Convert.IsDBNull(reader["RecordingEndTime"]))?DateTime.MinValue:(System.DateTime?)reader["RecordingEndTime"];
			entity.ModeratorCode = (reader.IsDBNull(((int)Vw_RecordingListColumn.ModeratorCode)))?null:(System.String)reader[((int)Vw_RecordingListColumn.ModeratorCode)];
			//entity.ModeratorCode = (Convert.IsDBNull(reader["ModeratorCode"]))?string.Empty:(System.String)reader["ModeratorCode"];
			entity.PassCode = (reader.IsDBNull(((int)Vw_RecordingListColumn.PassCode)))?null:(System.String)reader[((int)Vw_RecordingListColumn.PassCode)];
			//entity.PassCode = (Convert.IsDBNull(reader["PassCode"]))?string.Empty:(System.String)reader["PassCode"];
			entity.PriCustomerNumber = (reader.IsDBNull(((int)Vw_RecordingListColumn.PriCustomerNumber)))?null:(System.String)reader[((int)Vw_RecordingListColumn.PriCustomerNumber)];
			//entity.PriCustomerNumber = (Convert.IsDBNull(reader["PriCustomerNumber"]))?string.Empty:(System.String)reader["PriCustomerNumber"];
			entity.SecCustomerNumber = (reader.IsDBNull(((int)Vw_RecordingListColumn.SecCustomerNumber)))?null:(System.String)reader[((int)Vw_RecordingListColumn.SecCustomerNumber)];
			//entity.SecCustomerNumber = (Convert.IsDBNull(reader["SecCustomerNumber"]))?string.Empty:(System.String)reader["SecCustomerNumber"];
			entity.RecordingDirectory = (reader.IsDBNull(((int)Vw_RecordingListColumn.RecordingDirectory)))?null:(System.String)reader[((int)Vw_RecordingListColumn.RecordingDirectory)];
			//entity.RecordingDirectory = (Convert.IsDBNull(reader["RecordingDirectory"]))?string.Empty:(System.String)reader["RecordingDirectory"];
			entity.UniqueConferenceId = (reader.IsDBNull(((int)Vw_RecordingListColumn.UniqueConferenceId)))?null:(System.String)reader[((int)Vw_RecordingListColumn.UniqueConferenceId)];
			//entity.UniqueConferenceId = (Convert.IsDBNull(reader["UniqueConferenceID"]))?string.Empty:(System.String)reader["UniqueConferenceID"];
			entity.ReplayCode = (reader.IsDBNull(((int)Vw_RecordingListColumn.ReplayCode)))?null:(System.String)reader[((int)Vw_RecordingListColumn.ReplayCode)];
			//entity.ReplayCode = (Convert.IsDBNull(reader["ReplayCode"]))?string.Empty:(System.String)reader["ReplayCode"];
			entity.CreatedDate = (reader.IsDBNull(((int)Vw_RecordingListColumn.CreatedDate)))?null:(System.DateTime?)reader[((int)Vw_RecordingListColumn.CreatedDate)];
			//entity.CreatedDate = (Convert.IsDBNull(reader["CreatedDate"]))?DateTime.MinValue:(System.DateTime?)reader["CreatedDate"];
			entity.ProcessFlag = (reader.IsDBNull(((int)Vw_RecordingListColumn.ProcessFlag)))?null:(System.String)reader[((int)Vw_RecordingListColumn.ProcessFlag)];
			//entity.ProcessFlag = (Convert.IsDBNull(reader["ProcessFlag"]))?string.Empty:(System.String)reader["ProcessFlag"];
			entity.EmailSent = (reader.IsDBNull(((int)Vw_RecordingListColumn.EmailSent)))?null:(System.Boolean?)reader[((int)Vw_RecordingListColumn.EmailSent)];
			//entity.EmailSent = (Convert.IsDBNull(reader["EmailSent"]))?false:(System.Boolean?)reader["EmailSent"];
			entity.RpFileNumber = (reader.IsDBNull(((int)Vw_RecordingListColumn.RpFileNumber)))?null:(System.String)reader[((int)Vw_RecordingListColumn.RpFileNumber)];
			//entity.RpFileNumber = (Convert.IsDBNull(reader["RPFileNumber"]))?string.Empty:(System.String)reader["RPFileNumber"];
			entity.ModeratorId = (reader.IsDBNull(((int)Vw_RecordingListColumn.ModeratorId)))?null:(System.Int32?)reader[((int)Vw_RecordingListColumn.ModeratorId)];
			//entity.ModeratorId = (Convert.IsDBNull(reader["ModeratorID"]))?(int)0:(System.Int32?)reader["ModeratorID"];
			entity.Notes = (reader.IsDBNull(((int)Vw_RecordingListColumn.Notes)))?null:(System.String)reader[((int)Vw_RecordingListColumn.Notes)];
			//entity.Notes = (Convert.IsDBNull(reader["Notes"]))?string.Empty:(System.String)reader["Notes"];
			entity.Mp3Flag = (reader.IsDBNull(((int)Vw_RecordingListColumn.Mp3Flag)))?null:(System.String)reader[((int)Vw_RecordingListColumn.Mp3Flag)];
			//entity.Mp3Flag = (Convert.IsDBNull(reader["Mp3Flag"]))?string.Empty:(System.String)reader["Mp3Flag"];
			entity.Mp3SizeInKb = (reader.IsDBNull(((int)Vw_RecordingListColumn.Mp3SizeInKb)))?null:(System.Int32?)reader[((int)Vw_RecordingListColumn.Mp3SizeInKb)];
			//entity.Mp3SizeInKb = (Convert.IsDBNull(reader["Mp3SizeInKB"]))?(int)0:(System.Int32?)reader["Mp3SizeInKB"];
			entity.Enabled = (reader.IsDBNull(((int)Vw_RecordingListColumn.Enabled)))?null:(System.Boolean?)reader[((int)Vw_RecordingListColumn.Enabled)];
			//entity.Enabled = (Convert.IsDBNull(reader["Enabled"]))?false:(System.Boolean?)reader["Enabled"];
			entity.StorageDuration = (reader.IsDBNull(((int)Vw_RecordingListColumn.StorageDuration)))?null:(System.Int16?)reader[((int)Vw_RecordingListColumn.StorageDuration)];
			//entity.StorageDuration = (Convert.IsDBNull(reader["StorageDuration"]))?(short)0:(System.Int16?)reader["StorageDuration"];
			entity.BillingDuration = (reader.IsDBNull(((int)Vw_RecordingListColumn.BillingDuration)))?null:(System.Int16?)reader[((int)Vw_RecordingListColumn.BillingDuration)];
			//entity.BillingDuration = (Convert.IsDBNull(reader["BillingDuration"]))?(short)0:(System.Int16?)reader["BillingDuration"];
			entity.BillingId = (reader.IsDBNull(((int)Vw_RecordingListColumn.BillingId)))?null:(System.String)reader[((int)Vw_RecordingListColumn.BillingId)];
			//entity.BillingId = (Convert.IsDBNull(reader["BillingID"]))?string.Empty:(System.String)reader["BillingID"];
			entity.DurationSec = (reader.IsDBNull(((int)Vw_RecordingListColumn.DurationSec)))?null:(System.Int32?)reader[((int)Vw_RecordingListColumn.DurationSec)];
			//entity.DurationSec = (Convert.IsDBNull(reader["DurationSec"]))?(int)0:(System.Int32?)reader["DurationSec"];
			entity.AuxiliaryConferenceId = (reader.IsDBNull(((int)Vw_RecordingListColumn.AuxiliaryConferenceId)))?null:(System.String)reader[((int)Vw_RecordingListColumn.AuxiliaryConferenceId)];
			//entity.AuxiliaryConferenceId = (Convert.IsDBNull(reader["AuxiliaryConferenceID"]))?string.Empty:(System.String)reader["AuxiliaryConferenceID"];
			entity.MediaType = (reader.IsDBNull(((int)Vw_RecordingListColumn.MediaType)))?null:(System.String)reader[((int)Vw_RecordingListColumn.MediaType)];
			//entity.MediaType = (Convert.IsDBNull(reader["MediaType"]))?string.Empty:(System.String)reader["MediaType"];
			entity.HostedLinkExpiryDate = (reader.IsDBNull(((int)Vw_RecordingListColumn.HostedLinkExpiryDate)))?null:(System.DateTime?)reader[((int)Vw_RecordingListColumn.HostedLinkExpiryDate)];
			//entity.HostedLinkExpiryDate = (Convert.IsDBNull(reader["HostedLinkExpiryDate"]))?DateTime.MinValue:(System.DateTime?)reader["HostedLinkExpiryDate"];
			entity.ConferenceName = (reader.IsDBNull(((int)Vw_RecordingListColumn.ConferenceName)))?null:(System.String)reader[((int)Vw_RecordingListColumn.ConferenceName)];
			//entity.ConferenceName = (Convert.IsDBNull(reader["ConferenceName"]))?string.Empty:(System.String)reader["ConferenceName"];
			entity.Username = (System.String)reader[((int)Vw_RecordingListColumn.Username)];
			//entity.Username = (Convert.IsDBNull(reader["Username"]))?string.Empty:(System.String)reader["Username"];
			entity.DisplayName = (System.String)reader[((int)Vw_RecordingListColumn.DisplayName)];
			//entity.DisplayName = (Convert.IsDBNull(reader["DisplayName"]))?string.Empty:(System.String)reader["DisplayName"];
			entity.ExtendRecordingDate = (reader.IsDBNull(((int)Vw_RecordingListColumn.ExtendRecordingDate)))?null:(System.DateTime?)reader[((int)Vw_RecordingListColumn.ExtendRecordingDate)];
			//entity.ExtendRecordingDate = (Convert.IsDBNull(reader["ExtendRecordingDate"]))?DateTime.MinValue:(System.DateTime?)reader["ExtendRecordingDate"];
			entity.UserId = (System.Int32)reader[((int)Vw_RecordingListColumn.UserId)];
			//entity.UserId = (Convert.IsDBNull(reader["UserID"]))?(int)0:(System.Int32)reader["UserID"];
			entity.HostedLinkType = (reader.IsDBNull(((int)Vw_RecordingListColumn.HostedLinkType)))?null:(System.String)reader[((int)Vw_RecordingListColumn.HostedLinkType)];
			//entity.HostedLinkType = (Convert.IsDBNull(reader["HostedLinkType"]))?string.Empty:(System.String)reader["HostedLinkType"];
			entity.HostedLinkUrl = (reader.IsDBNull(((int)Vw_RecordingListColumn.HostedLinkUrl)))?null:(System.String)reader[((int)Vw_RecordingListColumn.HostedLinkUrl)];
			//entity.HostedLinkUrl = (Convert.IsDBNull(reader["HostedLinkURL"]))?string.Empty:(System.String)reader["HostedLinkURL"];
			entity.RecordingGuid = (reader.IsDBNull(((int)Vw_RecordingListColumn.RecordingGuid)))?null:(System.String)reader[((int)Vw_RecordingListColumn.RecordingGuid)];
			//entity.RecordingGuid = (Convert.IsDBNull(reader["RecordingGuid"]))?string.Empty:(System.String)reader["RecordingGuid"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="Vw_RecordingList"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Vw_RecordingList"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, Vw_RecordingList entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (Convert.IsDBNull(dataRow["ID"]))?(int)0:(System.Int32)dataRow["ID"];
			entity.WholesalerId = (Convert.IsDBNull(dataRow["WholesalerID"]))?string.Empty:(System.String)dataRow["WholesalerID"];
			entity.BridgeId = (Convert.IsDBNull(dataRow["BridgeID"]))?(int)0:(System.Int32?)dataRow["BridgeID"];
			entity.RecordingStartTime = (Convert.IsDBNull(dataRow["RecordingStartTime"]))?DateTime.MinValue:(System.DateTime?)dataRow["RecordingStartTime"];
			entity.RecordingEndTime = (Convert.IsDBNull(dataRow["RecordingEndTime"]))?DateTime.MinValue:(System.DateTime?)dataRow["RecordingEndTime"];
			entity.ModeratorCode = (Convert.IsDBNull(dataRow["ModeratorCode"]))?string.Empty:(System.String)dataRow["ModeratorCode"];
			entity.PassCode = (Convert.IsDBNull(dataRow["PassCode"]))?string.Empty:(System.String)dataRow["PassCode"];
			entity.PriCustomerNumber = (Convert.IsDBNull(dataRow["PriCustomerNumber"]))?string.Empty:(System.String)dataRow["PriCustomerNumber"];
			entity.SecCustomerNumber = (Convert.IsDBNull(dataRow["SecCustomerNumber"]))?string.Empty:(System.String)dataRow["SecCustomerNumber"];
			entity.RecordingDirectory = (Convert.IsDBNull(dataRow["RecordingDirectory"]))?string.Empty:(System.String)dataRow["RecordingDirectory"];
			entity.UniqueConferenceId = (Convert.IsDBNull(dataRow["UniqueConferenceID"]))?string.Empty:(System.String)dataRow["UniqueConferenceID"];
			entity.ReplayCode = (Convert.IsDBNull(dataRow["ReplayCode"]))?string.Empty:(System.String)dataRow["ReplayCode"];
			entity.CreatedDate = (Convert.IsDBNull(dataRow["CreatedDate"]))?DateTime.MinValue:(System.DateTime?)dataRow["CreatedDate"];
			entity.ProcessFlag = (Convert.IsDBNull(dataRow["ProcessFlag"]))?string.Empty:(System.String)dataRow["ProcessFlag"];
			entity.EmailSent = (Convert.IsDBNull(dataRow["EmailSent"]))?false:(System.Boolean?)dataRow["EmailSent"];
			entity.RpFileNumber = (Convert.IsDBNull(dataRow["RPFileNumber"]))?string.Empty:(System.String)dataRow["RPFileNumber"];
			entity.ModeratorId = (Convert.IsDBNull(dataRow["ModeratorID"]))?(int)0:(System.Int32?)dataRow["ModeratorID"];
			entity.Notes = (Convert.IsDBNull(dataRow["Notes"]))?string.Empty:(System.String)dataRow["Notes"];
			entity.Mp3Flag = (Convert.IsDBNull(dataRow["Mp3Flag"]))?string.Empty:(System.String)dataRow["Mp3Flag"];
			entity.Mp3SizeInKb = (Convert.IsDBNull(dataRow["Mp3SizeInKB"]))?(int)0:(System.Int32?)dataRow["Mp3SizeInKB"];
			entity.Enabled = (Convert.IsDBNull(dataRow["Enabled"]))?false:(System.Boolean?)dataRow["Enabled"];
			entity.StorageDuration = (Convert.IsDBNull(dataRow["StorageDuration"]))?(short)0:(System.Int16?)dataRow["StorageDuration"];
			entity.BillingDuration = (Convert.IsDBNull(dataRow["BillingDuration"]))?(short)0:(System.Int16?)dataRow["BillingDuration"];
			entity.BillingId = (Convert.IsDBNull(dataRow["BillingID"]))?string.Empty:(System.String)dataRow["BillingID"];
			entity.DurationSec = (Convert.IsDBNull(dataRow["DurationSec"]))?(int)0:(System.Int32?)dataRow["DurationSec"];
			entity.AuxiliaryConferenceId = (Convert.IsDBNull(dataRow["AuxiliaryConferenceID"]))?string.Empty:(System.String)dataRow["AuxiliaryConferenceID"];
			entity.MediaType = (Convert.IsDBNull(dataRow["MediaType"]))?string.Empty:(System.String)dataRow["MediaType"];
			entity.HostedLinkExpiryDate = (Convert.IsDBNull(dataRow["HostedLinkExpiryDate"]))?DateTime.MinValue:(System.DateTime?)dataRow["HostedLinkExpiryDate"];
			entity.ConferenceName = (Convert.IsDBNull(dataRow["ConferenceName"]))?string.Empty:(System.String)dataRow["ConferenceName"];
			entity.Username = (Convert.IsDBNull(dataRow["Username"]))?string.Empty:(System.String)dataRow["Username"];
			entity.DisplayName = (Convert.IsDBNull(dataRow["DisplayName"]))?string.Empty:(System.String)dataRow["DisplayName"];
			entity.ExtendRecordingDate = (Convert.IsDBNull(dataRow["ExtendRecordingDate"]))?DateTime.MinValue:(System.DateTime?)dataRow["ExtendRecordingDate"];
			entity.UserId = (Convert.IsDBNull(dataRow["UserID"]))?(int)0:(System.Int32)dataRow["UserID"];
			entity.HostedLinkType = (Convert.IsDBNull(dataRow["HostedLinkType"]))?string.Empty:(System.String)dataRow["HostedLinkType"];
			entity.HostedLinkUrl = (Convert.IsDBNull(dataRow["HostedLinkURL"]))?string.Empty:(System.String)dataRow["HostedLinkURL"];
			entity.RecordingGuid = (Convert.IsDBNull(dataRow["RecordingGuid"]))?string.Empty:(System.String)dataRow["RecordingGuid"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region Vw_RecordingListFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_RecordingList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_RecordingListFilterBuilder : SqlFilterBuilder<Vw_RecordingListColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_RecordingListFilterBuilder class.
		/// </summary>
		public Vw_RecordingListFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_RecordingListFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_RecordingListFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_RecordingListFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_RecordingListFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_RecordingListFilterBuilder

	#region Vw_RecordingListParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_RecordingList"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_RecordingListParameterBuilder : ParameterizedSqlFilterBuilder<Vw_RecordingListColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_RecordingListParameterBuilder class.
		/// </summary>
		public Vw_RecordingListParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_RecordingListParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_RecordingListParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_RecordingListParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_RecordingListParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_RecordingListParameterBuilder
} // end namespace
