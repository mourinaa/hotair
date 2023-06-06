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
	/// This class is the base class for any <see cref="Vw_ConferenceCallList_UniqueProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class Vw_ConferenceCallList_UniqueProviderBaseCore : EntityViewProviderBase<Vw_ConferenceCallList_Unique>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;Vw_ConferenceCallList_Unique&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;Vw_ConferenceCallList_Unique&gt;"/></returns>
		protected static VList&lt;Vw_ConferenceCallList_Unique&gt; Fill(DataSet dataSet, VList<Vw_ConferenceCallList_Unique> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<Vw_ConferenceCallList_Unique>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;Vw_ConferenceCallList_Unique&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<Vw_ConferenceCallList_Unique>"/></returns>
		protected static VList&lt;Vw_ConferenceCallList_Unique&gt; Fill(DataTable dataTable, VList<Vw_ConferenceCallList_Unique> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					Vw_ConferenceCallList_Unique c = new Vw_ConferenceCallList_Unique();
					c.ModeratorId = (Convert.IsDBNull(row["ModeratorID"]))?(int)0:(System.Int32)row["ModeratorID"];
					c.CustomerId = (Convert.IsDBNull(row["CustomerID"]))?(int)0:(System.Int32?)row["CustomerID"];
					c.WholesalerId = (Convert.IsDBNull(row["WholesalerID"]))?string.Empty:(System.String)row["WholesalerID"];
					c.ModeratorName = (Convert.IsDBNull(row["ModeratorName"]))?string.Empty:(System.String)row["ModeratorName"];
					c.ConferenceStartTime = (Convert.IsDBNull(row["ConferenceStartTime"]))?DateTime.MinValue:(System.DateTime?)row["ConferenceStartTime"];
					c.UniqueConferenceId = (Convert.IsDBNull(row["UniqueConferenceID"]))?string.Empty:(System.String)row["UniqueConferenceID"];
					c.NumberPeopleOnCall = (Convert.IsDBNull(row["NumberPeopleOnCall"]))?(int)0:(System.Int32?)row["NumberPeopleOnCall"];
					c.AuxiliaryConferenceId = (Convert.IsDBNull(row["AuxiliaryConferenceID"]))?string.Empty:(System.String)row["AuxiliaryConferenceID"];
					c.ReferenceNumber = (Convert.IsDBNull(row["ReferenceNumber"]))?string.Empty:(System.String)row["ReferenceNumber"];
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
		/// Fill an <see cref="VList&lt;Vw_ConferenceCallList_Unique&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;Vw_ConferenceCallList_Unique&gt;"/></returns>
		protected VList<Vw_ConferenceCallList_Unique> Fill(IDataReader reader, VList<Vw_ConferenceCallList_Unique> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					Vw_ConferenceCallList_Unique entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<Vw_ConferenceCallList_Unique>("Vw_ConferenceCallList_Unique",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new Vw_ConferenceCallList_Unique();
					}
					
					entity.SuppressEntityEvents = true;

					entity.ModeratorId = (System.Int32)reader[((int)Vw_ConferenceCallList_UniqueColumn.ModeratorId)];
					//entity.ModeratorId = (Convert.IsDBNull(reader["ModeratorID"]))?(int)0:(System.Int32)reader["ModeratorID"];
					entity.CustomerId = (reader.IsDBNull(((int)Vw_ConferenceCallList_UniqueColumn.CustomerId)))?null:(System.Int32?)reader[((int)Vw_ConferenceCallList_UniqueColumn.CustomerId)];
					//entity.CustomerId = (Convert.IsDBNull(reader["CustomerID"]))?(int)0:(System.Int32?)reader["CustomerID"];
					entity.WholesalerId = (reader.IsDBNull(((int)Vw_ConferenceCallList_UniqueColumn.WholesalerId)))?null:(System.String)reader[((int)Vw_ConferenceCallList_UniqueColumn.WholesalerId)];
					//entity.WholesalerId = (Convert.IsDBNull(reader["WholesalerID"]))?string.Empty:(System.String)reader["WholesalerID"];
					entity.ModeratorName = (reader.IsDBNull(((int)Vw_ConferenceCallList_UniqueColumn.ModeratorName)))?null:(System.String)reader[((int)Vw_ConferenceCallList_UniqueColumn.ModeratorName)];
					//entity.ModeratorName = (Convert.IsDBNull(reader["ModeratorName"]))?string.Empty:(System.String)reader["ModeratorName"];
					entity.ConferenceStartTime = (reader.IsDBNull(((int)Vw_ConferenceCallList_UniqueColumn.ConferenceStartTime)))?null:(System.DateTime?)reader[((int)Vw_ConferenceCallList_UniqueColumn.ConferenceStartTime)];
					//entity.ConferenceStartTime = (Convert.IsDBNull(reader["ConferenceStartTime"]))?DateTime.MinValue:(System.DateTime?)reader["ConferenceStartTime"];
					entity.UniqueConferenceId = (reader.IsDBNull(((int)Vw_ConferenceCallList_UniqueColumn.UniqueConferenceId)))?null:(System.String)reader[((int)Vw_ConferenceCallList_UniqueColumn.UniqueConferenceId)];
					//entity.UniqueConferenceId = (Convert.IsDBNull(reader["UniqueConferenceID"]))?string.Empty:(System.String)reader["UniqueConferenceID"];
					entity.NumberPeopleOnCall = (reader.IsDBNull(((int)Vw_ConferenceCallList_UniqueColumn.NumberPeopleOnCall)))?null:(System.Int32?)reader[((int)Vw_ConferenceCallList_UniqueColumn.NumberPeopleOnCall)];
					//entity.NumberPeopleOnCall = (Convert.IsDBNull(reader["NumberPeopleOnCall"]))?(int)0:(System.Int32?)reader["NumberPeopleOnCall"];
					entity.AuxiliaryConferenceId = (reader.IsDBNull(((int)Vw_ConferenceCallList_UniqueColumn.AuxiliaryConferenceId)))?null:(System.String)reader[((int)Vw_ConferenceCallList_UniqueColumn.AuxiliaryConferenceId)];
					//entity.AuxiliaryConferenceId = (Convert.IsDBNull(reader["AuxiliaryConferenceID"]))?string.Empty:(System.String)reader["AuxiliaryConferenceID"];
					entity.ReferenceNumber = (reader.IsDBNull(((int)Vw_ConferenceCallList_UniqueColumn.ReferenceNumber)))?null:(System.String)reader[((int)Vw_ConferenceCallList_UniqueColumn.ReferenceNumber)];
					//entity.ReferenceNumber = (Convert.IsDBNull(reader["ReferenceNumber"]))?string.Empty:(System.String)reader["ReferenceNumber"];
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
		/// Refreshes the <see cref="Vw_ConferenceCallList_Unique"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Vw_ConferenceCallList_Unique"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, Vw_ConferenceCallList_Unique entity)
		{
			reader.Read();
			entity.ModeratorId = (System.Int32)reader[((int)Vw_ConferenceCallList_UniqueColumn.ModeratorId)];
			//entity.ModeratorId = (Convert.IsDBNull(reader["ModeratorID"]))?(int)0:(System.Int32)reader["ModeratorID"];
			entity.CustomerId = (reader.IsDBNull(((int)Vw_ConferenceCallList_UniqueColumn.CustomerId)))?null:(System.Int32?)reader[((int)Vw_ConferenceCallList_UniqueColumn.CustomerId)];
			//entity.CustomerId = (Convert.IsDBNull(reader["CustomerID"]))?(int)0:(System.Int32?)reader["CustomerID"];
			entity.WholesalerId = (reader.IsDBNull(((int)Vw_ConferenceCallList_UniqueColumn.WholesalerId)))?null:(System.String)reader[((int)Vw_ConferenceCallList_UniqueColumn.WholesalerId)];
			//entity.WholesalerId = (Convert.IsDBNull(reader["WholesalerID"]))?string.Empty:(System.String)reader["WholesalerID"];
			entity.ModeratorName = (reader.IsDBNull(((int)Vw_ConferenceCallList_UniqueColumn.ModeratorName)))?null:(System.String)reader[((int)Vw_ConferenceCallList_UniqueColumn.ModeratorName)];
			//entity.ModeratorName = (Convert.IsDBNull(reader["ModeratorName"]))?string.Empty:(System.String)reader["ModeratorName"];
			entity.ConferenceStartTime = (reader.IsDBNull(((int)Vw_ConferenceCallList_UniqueColumn.ConferenceStartTime)))?null:(System.DateTime?)reader[((int)Vw_ConferenceCallList_UniqueColumn.ConferenceStartTime)];
			//entity.ConferenceStartTime = (Convert.IsDBNull(reader["ConferenceStartTime"]))?DateTime.MinValue:(System.DateTime?)reader["ConferenceStartTime"];
			entity.UniqueConferenceId = (reader.IsDBNull(((int)Vw_ConferenceCallList_UniqueColumn.UniqueConferenceId)))?null:(System.String)reader[((int)Vw_ConferenceCallList_UniqueColumn.UniqueConferenceId)];
			//entity.UniqueConferenceId = (Convert.IsDBNull(reader["UniqueConferenceID"]))?string.Empty:(System.String)reader["UniqueConferenceID"];
			entity.NumberPeopleOnCall = (reader.IsDBNull(((int)Vw_ConferenceCallList_UniqueColumn.NumberPeopleOnCall)))?null:(System.Int32?)reader[((int)Vw_ConferenceCallList_UniqueColumn.NumberPeopleOnCall)];
			//entity.NumberPeopleOnCall = (Convert.IsDBNull(reader["NumberPeopleOnCall"]))?(int)0:(System.Int32?)reader["NumberPeopleOnCall"];
			entity.AuxiliaryConferenceId = (reader.IsDBNull(((int)Vw_ConferenceCallList_UniqueColumn.AuxiliaryConferenceId)))?null:(System.String)reader[((int)Vw_ConferenceCallList_UniqueColumn.AuxiliaryConferenceId)];
			//entity.AuxiliaryConferenceId = (Convert.IsDBNull(reader["AuxiliaryConferenceID"]))?string.Empty:(System.String)reader["AuxiliaryConferenceID"];
			entity.ReferenceNumber = (reader.IsDBNull(((int)Vw_ConferenceCallList_UniqueColumn.ReferenceNumber)))?null:(System.String)reader[((int)Vw_ConferenceCallList_UniqueColumn.ReferenceNumber)];
			//entity.ReferenceNumber = (Convert.IsDBNull(reader["ReferenceNumber"]))?string.Empty:(System.String)reader["ReferenceNumber"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="Vw_ConferenceCallList_Unique"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Vw_ConferenceCallList_Unique"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, Vw_ConferenceCallList_Unique entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.ModeratorId = (Convert.IsDBNull(dataRow["ModeratorID"]))?(int)0:(System.Int32)dataRow["ModeratorID"];
			entity.CustomerId = (Convert.IsDBNull(dataRow["CustomerID"]))?(int)0:(System.Int32?)dataRow["CustomerID"];
			entity.WholesalerId = (Convert.IsDBNull(dataRow["WholesalerID"]))?string.Empty:(System.String)dataRow["WholesalerID"];
			entity.ModeratorName = (Convert.IsDBNull(dataRow["ModeratorName"]))?string.Empty:(System.String)dataRow["ModeratorName"];
			entity.ConferenceStartTime = (Convert.IsDBNull(dataRow["ConferenceStartTime"]))?DateTime.MinValue:(System.DateTime?)dataRow["ConferenceStartTime"];
			entity.UniqueConferenceId = (Convert.IsDBNull(dataRow["UniqueConferenceID"]))?string.Empty:(System.String)dataRow["UniqueConferenceID"];
			entity.NumberPeopleOnCall = (Convert.IsDBNull(dataRow["NumberPeopleOnCall"]))?(int)0:(System.Int32?)dataRow["NumberPeopleOnCall"];
			entity.AuxiliaryConferenceId = (Convert.IsDBNull(dataRow["AuxiliaryConferenceID"]))?string.Empty:(System.String)dataRow["AuxiliaryConferenceID"];
			entity.ReferenceNumber = (Convert.IsDBNull(dataRow["ReferenceNumber"]))?string.Empty:(System.String)dataRow["ReferenceNumber"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region Vw_ConferenceCallList_UniqueFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_ConferenceCallList_Unique"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_ConferenceCallList_UniqueFilterBuilder : SqlFilterBuilder<Vw_ConferenceCallList_UniqueColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_ConferenceCallList_UniqueFilterBuilder class.
		/// </summary>
		public Vw_ConferenceCallList_UniqueFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_ConferenceCallList_UniqueFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_ConferenceCallList_UniqueFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_ConferenceCallList_UniqueFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_ConferenceCallList_UniqueFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_ConferenceCallList_UniqueFilterBuilder

	#region Vw_ConferenceCallList_UniqueParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_ConferenceCallList_Unique"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_ConferenceCallList_UniqueParameterBuilder : ParameterizedSqlFilterBuilder<Vw_ConferenceCallList_UniqueColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_ConferenceCallList_UniqueParameterBuilder class.
		/// </summary>
		public Vw_ConferenceCallList_UniqueParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_ConferenceCallList_UniqueParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_ConferenceCallList_UniqueParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_ConferenceCallList_UniqueParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_ConferenceCallList_UniqueParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_ConferenceCallList_UniqueParameterBuilder
} // end namespace
