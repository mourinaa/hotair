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
	/// This class is the base class for any <see cref="Vw_SystemExtension_ValueProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class Vw_SystemExtension_ValueProviderBaseCore : EntityViewProviderBase<Vw_SystemExtension_Value>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;Vw_SystemExtension_Value&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;Vw_SystemExtension_Value&gt;"/></returns>
		protected static VList&lt;Vw_SystemExtension_Value&gt; Fill(DataSet dataSet, VList<Vw_SystemExtension_Value> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<Vw_SystemExtension_Value>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;Vw_SystemExtension_Value&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<Vw_SystemExtension_Value>"/></returns>
		protected static VList&lt;Vw_SystemExtension_Value&gt; Fill(DataTable dataTable, VList<Vw_SystemExtension_Value> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					Vw_SystemExtension_Value c = new Vw_SystemExtension_Value();
					c.CustomerId = (Convert.IsDBNull(row["CustomerID"]))?(int)0:(System.Int32)row["CustomerID"];
					c.ModeratorId = (Convert.IsDBNull(row["ModeratorID"]))?(int)0:(System.Int32)row["ModeratorID"];
					c.EmployeeId = (Convert.IsDBNull(row["EmployeeID"]))?string.Empty:(System.String)row["EmployeeID"];
					c.CostCenter = (Convert.IsDBNull(row["CostCenter"]))?string.Empty:(System.String)row["CostCenter"];
					c.EZuceh323Pin = (Convert.IsDBNull(row["eZuceH323PIN"]))?string.Empty:(System.String)row["eZuceH323PIN"];
					c.EZuceMeetingId = (Convert.IsDBNull(row["eZuceMeetingID"]))?string.Empty:(System.String)row["eZuceMeetingID"];
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
		/// Fill an <see cref="VList&lt;Vw_SystemExtension_Value&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;Vw_SystemExtension_Value&gt;"/></returns>
		protected VList<Vw_SystemExtension_Value> Fill(IDataReader reader, VList<Vw_SystemExtension_Value> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					Vw_SystemExtension_Value entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<Vw_SystemExtension_Value>("Vw_SystemExtension_Value",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new Vw_SystemExtension_Value();
					}
					
					entity.SuppressEntityEvents = true;

					entity.CustomerId = (System.Int32)reader[((int)Vw_SystemExtension_ValueColumn.CustomerId)];
					//entity.CustomerId = (Convert.IsDBNull(reader["CustomerID"]))?(int)0:(System.Int32)reader["CustomerID"];
					entity.ModeratorId = (System.Int32)reader[((int)Vw_SystemExtension_ValueColumn.ModeratorId)];
					//entity.ModeratorId = (Convert.IsDBNull(reader["ModeratorID"]))?(int)0:(System.Int32)reader["ModeratorID"];
					entity.EmployeeId = (reader.IsDBNull(((int)Vw_SystemExtension_ValueColumn.EmployeeId)))?null:(System.String)reader[((int)Vw_SystemExtension_ValueColumn.EmployeeId)];
					//entity.EmployeeId = (Convert.IsDBNull(reader["EmployeeID"]))?string.Empty:(System.String)reader["EmployeeID"];
					entity.CostCenter = (reader.IsDBNull(((int)Vw_SystemExtension_ValueColumn.CostCenter)))?null:(System.String)reader[((int)Vw_SystemExtension_ValueColumn.CostCenter)];
					//entity.CostCenter = (Convert.IsDBNull(reader["CostCenter"]))?string.Empty:(System.String)reader["CostCenter"];
					entity.EZuceh323Pin = (reader.IsDBNull(((int)Vw_SystemExtension_ValueColumn.EZuceh323Pin)))?null:(System.String)reader[((int)Vw_SystemExtension_ValueColumn.EZuceh323Pin)];
					//entity.EZuceh323Pin = (Convert.IsDBNull(reader["eZuceH323PIN"]))?string.Empty:(System.String)reader["eZuceH323PIN"];
					entity.EZuceMeetingId = (reader.IsDBNull(((int)Vw_SystemExtension_ValueColumn.EZuceMeetingId)))?null:(System.String)reader[((int)Vw_SystemExtension_ValueColumn.EZuceMeetingId)];
					//entity.EZuceMeetingId = (Convert.IsDBNull(reader["eZuceMeetingID"]))?string.Empty:(System.String)reader["eZuceMeetingID"];
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
		/// Refreshes the <see cref="Vw_SystemExtension_Value"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Vw_SystemExtension_Value"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, Vw_SystemExtension_Value entity)
		{
			reader.Read();
			entity.CustomerId = (System.Int32)reader[((int)Vw_SystemExtension_ValueColumn.CustomerId)];
			//entity.CustomerId = (Convert.IsDBNull(reader["CustomerID"]))?(int)0:(System.Int32)reader["CustomerID"];
			entity.ModeratorId = (System.Int32)reader[((int)Vw_SystemExtension_ValueColumn.ModeratorId)];
			//entity.ModeratorId = (Convert.IsDBNull(reader["ModeratorID"]))?(int)0:(System.Int32)reader["ModeratorID"];
			entity.EmployeeId = (reader.IsDBNull(((int)Vw_SystemExtension_ValueColumn.EmployeeId)))?null:(System.String)reader[((int)Vw_SystemExtension_ValueColumn.EmployeeId)];
			//entity.EmployeeId = (Convert.IsDBNull(reader["EmployeeID"]))?string.Empty:(System.String)reader["EmployeeID"];
			entity.CostCenter = (reader.IsDBNull(((int)Vw_SystemExtension_ValueColumn.CostCenter)))?null:(System.String)reader[((int)Vw_SystemExtension_ValueColumn.CostCenter)];
			//entity.CostCenter = (Convert.IsDBNull(reader["CostCenter"]))?string.Empty:(System.String)reader["CostCenter"];
			entity.EZuceh323Pin = (reader.IsDBNull(((int)Vw_SystemExtension_ValueColumn.EZuceh323Pin)))?null:(System.String)reader[((int)Vw_SystemExtension_ValueColumn.EZuceh323Pin)];
			//entity.EZuceh323Pin = (Convert.IsDBNull(reader["eZuceH323PIN"]))?string.Empty:(System.String)reader["eZuceH323PIN"];
			entity.EZuceMeetingId = (reader.IsDBNull(((int)Vw_SystemExtension_ValueColumn.EZuceMeetingId)))?null:(System.String)reader[((int)Vw_SystemExtension_ValueColumn.EZuceMeetingId)];
			//entity.EZuceMeetingId = (Convert.IsDBNull(reader["eZuceMeetingID"]))?string.Empty:(System.String)reader["eZuceMeetingID"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="Vw_SystemExtension_Value"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Vw_SystemExtension_Value"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, Vw_SystemExtension_Value entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CustomerId = (Convert.IsDBNull(dataRow["CustomerID"]))?(int)0:(System.Int32)dataRow["CustomerID"];
			entity.ModeratorId = (Convert.IsDBNull(dataRow["ModeratorID"]))?(int)0:(System.Int32)dataRow["ModeratorID"];
			entity.EmployeeId = (Convert.IsDBNull(dataRow["EmployeeID"]))?string.Empty:(System.String)dataRow["EmployeeID"];
			entity.CostCenter = (Convert.IsDBNull(dataRow["CostCenter"]))?string.Empty:(System.String)dataRow["CostCenter"];
			entity.EZuceh323Pin = (Convert.IsDBNull(dataRow["eZuceH323PIN"]))?string.Empty:(System.String)dataRow["eZuceH323PIN"];
			entity.EZuceMeetingId = (Convert.IsDBNull(dataRow["eZuceMeetingID"]))?string.Empty:(System.String)dataRow["eZuceMeetingID"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region Vw_SystemExtension_ValueFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_SystemExtension_Value"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_SystemExtension_ValueFilterBuilder : SqlFilterBuilder<Vw_SystemExtension_ValueColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_SystemExtension_ValueFilterBuilder class.
		/// </summary>
		public Vw_SystemExtension_ValueFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_SystemExtension_ValueFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_SystemExtension_ValueFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_SystemExtension_ValueFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_SystemExtension_ValueFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_SystemExtension_ValueFilterBuilder

	#region Vw_SystemExtension_ValueParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_SystemExtension_Value"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_SystemExtension_ValueParameterBuilder : ParameterizedSqlFilterBuilder<Vw_SystemExtension_ValueColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_SystemExtension_ValueParameterBuilder class.
		/// </summary>
		public Vw_SystemExtension_ValueParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_SystemExtension_ValueParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_SystemExtension_ValueParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_SystemExtension_ValueParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_SystemExtension_ValueParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_SystemExtension_ValueParameterBuilder
} // end namespace
