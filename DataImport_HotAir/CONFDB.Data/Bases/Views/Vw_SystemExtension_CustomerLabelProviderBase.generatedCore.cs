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
	/// This class is the base class for any <see cref="Vw_SystemExtension_CustomerLabelProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class Vw_SystemExtension_CustomerLabelProviderBaseCore : EntityViewProviderBase<Vw_SystemExtension_CustomerLabel>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;Vw_SystemExtension_CustomerLabel&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;Vw_SystemExtension_CustomerLabel&gt;"/></returns>
		protected static VList&lt;Vw_SystemExtension_CustomerLabel&gt; Fill(DataSet dataSet, VList<Vw_SystemExtension_CustomerLabel> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<Vw_SystemExtension_CustomerLabel>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;Vw_SystemExtension_CustomerLabel&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<Vw_SystemExtension_CustomerLabel>"/></returns>
		protected static VList&lt;Vw_SystemExtension_CustomerLabel&gt; Fill(DataTable dataTable, VList<Vw_SystemExtension_CustomerLabel> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					Vw_SystemExtension_CustomerLabel c = new Vw_SystemExtension_CustomerLabel();
					c.CustomerId = (Convert.IsDBNull(row["CustomerID"]))?(int)0:(System.Int32)row["CustomerID"];
					c.Name = (Convert.IsDBNull(row["Name"]))?string.Empty:(System.String)row["Name"];
					c.ExtensionTypeLabel = (Convert.IsDBNull(row["ExtensionTypeLabel"]))?string.Empty:(System.String)row["ExtensionTypeLabel"];
					c.ExtensionTypeCategoryId = (Convert.IsDBNull(row["ExtensionTypeCategoryID"]))?(int)0:(System.Int32)row["ExtensionTypeCategoryID"];
					c.ExtensionTypeId = (Convert.IsDBNull(row["ExtensionTypeID"]))?(int)0:(System.Int32)row["ExtensionTypeID"];
					c.CustomerCanView = (Convert.IsDBNull(row["CustomerCanView"]))?false:(System.Boolean)row["CustomerCanView"];
					c.ModeratorCanView = (Convert.IsDBNull(row["ModeratorCanView"]))?false:(System.Boolean)row["ModeratorCanView"];
					c.CustomerCanEdit = (Convert.IsDBNull(row["CustomerCanEdit"]))?false:(System.Boolean)row["CustomerCanEdit"];
					c.ModeratorCanEdit = (Convert.IsDBNull(row["ModeratorCanEdit"]))?false:(System.Boolean)row["ModeratorCanEdit"];
					c.Id = (Convert.IsDBNull(row["id"]))?(int)0:(System.Int32)row["id"];
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
		/// Fill an <see cref="VList&lt;Vw_SystemExtension_CustomerLabel&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;Vw_SystemExtension_CustomerLabel&gt;"/></returns>
		protected VList<Vw_SystemExtension_CustomerLabel> Fill(IDataReader reader, VList<Vw_SystemExtension_CustomerLabel> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					Vw_SystemExtension_CustomerLabel entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<Vw_SystemExtension_CustomerLabel>("Vw_SystemExtension_CustomerLabel",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new Vw_SystemExtension_CustomerLabel();
					}
					
					entity.SuppressEntityEvents = true;

					entity.CustomerId = (System.Int32)reader[((int)Vw_SystemExtension_CustomerLabelColumn.CustomerId)];
					//entity.CustomerId = (Convert.IsDBNull(reader["CustomerID"]))?(int)0:(System.Int32)reader["CustomerID"];
					entity.Name = (System.String)reader[((int)Vw_SystemExtension_CustomerLabelColumn.Name)];
					//entity.Name = (Convert.IsDBNull(reader["Name"]))?string.Empty:(System.String)reader["Name"];
					entity.ExtensionTypeLabel = (System.String)reader[((int)Vw_SystemExtension_CustomerLabelColumn.ExtensionTypeLabel)];
					//entity.ExtensionTypeLabel = (Convert.IsDBNull(reader["ExtensionTypeLabel"]))?string.Empty:(System.String)reader["ExtensionTypeLabel"];
					entity.ExtensionTypeCategoryId = (System.Int32)reader[((int)Vw_SystemExtension_CustomerLabelColumn.ExtensionTypeCategoryId)];
					//entity.ExtensionTypeCategoryId = (Convert.IsDBNull(reader["ExtensionTypeCategoryID"]))?(int)0:(System.Int32)reader["ExtensionTypeCategoryID"];
					entity.ExtensionTypeId = (System.Int32)reader[((int)Vw_SystemExtension_CustomerLabelColumn.ExtensionTypeId)];
					//entity.ExtensionTypeId = (Convert.IsDBNull(reader["ExtensionTypeID"]))?(int)0:(System.Int32)reader["ExtensionTypeID"];
					entity.CustomerCanView = (System.Boolean)reader[((int)Vw_SystemExtension_CustomerLabelColumn.CustomerCanView)];
					//entity.CustomerCanView = (Convert.IsDBNull(reader["CustomerCanView"]))?false:(System.Boolean)reader["CustomerCanView"];
					entity.ModeratorCanView = (System.Boolean)reader[((int)Vw_SystemExtension_CustomerLabelColumn.ModeratorCanView)];
					//entity.ModeratorCanView = (Convert.IsDBNull(reader["ModeratorCanView"]))?false:(System.Boolean)reader["ModeratorCanView"];
					entity.CustomerCanEdit = (System.Boolean)reader[((int)Vw_SystemExtension_CustomerLabelColumn.CustomerCanEdit)];
					//entity.CustomerCanEdit = (Convert.IsDBNull(reader["CustomerCanEdit"]))?false:(System.Boolean)reader["CustomerCanEdit"];
					entity.ModeratorCanEdit = (System.Boolean)reader[((int)Vw_SystemExtension_CustomerLabelColumn.ModeratorCanEdit)];
					//entity.ModeratorCanEdit = (Convert.IsDBNull(reader["ModeratorCanEdit"]))?false:(System.Boolean)reader["ModeratorCanEdit"];
					entity.Id = (System.Int32)reader[((int)Vw_SystemExtension_CustomerLabelColumn.Id)];
					//entity.Id = (Convert.IsDBNull(reader["id"]))?(int)0:(System.Int32)reader["id"];
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
		/// Refreshes the <see cref="Vw_SystemExtension_CustomerLabel"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Vw_SystemExtension_CustomerLabel"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, Vw_SystemExtension_CustomerLabel entity)
		{
			reader.Read();
			entity.CustomerId = (System.Int32)reader[((int)Vw_SystemExtension_CustomerLabelColumn.CustomerId)];
			//entity.CustomerId = (Convert.IsDBNull(reader["CustomerID"]))?(int)0:(System.Int32)reader["CustomerID"];
			entity.Name = (System.String)reader[((int)Vw_SystemExtension_CustomerLabelColumn.Name)];
			//entity.Name = (Convert.IsDBNull(reader["Name"]))?string.Empty:(System.String)reader["Name"];
			entity.ExtensionTypeLabel = (System.String)reader[((int)Vw_SystemExtension_CustomerLabelColumn.ExtensionTypeLabel)];
			//entity.ExtensionTypeLabel = (Convert.IsDBNull(reader["ExtensionTypeLabel"]))?string.Empty:(System.String)reader["ExtensionTypeLabel"];
			entity.ExtensionTypeCategoryId = (System.Int32)reader[((int)Vw_SystemExtension_CustomerLabelColumn.ExtensionTypeCategoryId)];
			//entity.ExtensionTypeCategoryId = (Convert.IsDBNull(reader["ExtensionTypeCategoryID"]))?(int)0:(System.Int32)reader["ExtensionTypeCategoryID"];
			entity.ExtensionTypeId = (System.Int32)reader[((int)Vw_SystemExtension_CustomerLabelColumn.ExtensionTypeId)];
			//entity.ExtensionTypeId = (Convert.IsDBNull(reader["ExtensionTypeID"]))?(int)0:(System.Int32)reader["ExtensionTypeID"];
			entity.CustomerCanView = (System.Boolean)reader[((int)Vw_SystemExtension_CustomerLabelColumn.CustomerCanView)];
			//entity.CustomerCanView = (Convert.IsDBNull(reader["CustomerCanView"]))?false:(System.Boolean)reader["CustomerCanView"];
			entity.ModeratorCanView = (System.Boolean)reader[((int)Vw_SystemExtension_CustomerLabelColumn.ModeratorCanView)];
			//entity.ModeratorCanView = (Convert.IsDBNull(reader["ModeratorCanView"]))?false:(System.Boolean)reader["ModeratorCanView"];
			entity.CustomerCanEdit = (System.Boolean)reader[((int)Vw_SystemExtension_CustomerLabelColumn.CustomerCanEdit)];
			//entity.CustomerCanEdit = (Convert.IsDBNull(reader["CustomerCanEdit"]))?false:(System.Boolean)reader["CustomerCanEdit"];
			entity.ModeratorCanEdit = (System.Boolean)reader[((int)Vw_SystemExtension_CustomerLabelColumn.ModeratorCanEdit)];
			//entity.ModeratorCanEdit = (Convert.IsDBNull(reader["ModeratorCanEdit"]))?false:(System.Boolean)reader["ModeratorCanEdit"];
			entity.Id = (System.Int32)reader[((int)Vw_SystemExtension_CustomerLabelColumn.Id)];
			//entity.Id = (Convert.IsDBNull(reader["id"]))?(int)0:(System.Int32)reader["id"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="Vw_SystemExtension_CustomerLabel"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Vw_SystemExtension_CustomerLabel"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, Vw_SystemExtension_CustomerLabel entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CustomerId = (Convert.IsDBNull(dataRow["CustomerID"]))?(int)0:(System.Int32)dataRow["CustomerID"];
			entity.Name = (Convert.IsDBNull(dataRow["Name"]))?string.Empty:(System.String)dataRow["Name"];
			entity.ExtensionTypeLabel = (Convert.IsDBNull(dataRow["ExtensionTypeLabel"]))?string.Empty:(System.String)dataRow["ExtensionTypeLabel"];
			entity.ExtensionTypeCategoryId = (Convert.IsDBNull(dataRow["ExtensionTypeCategoryID"]))?(int)0:(System.Int32)dataRow["ExtensionTypeCategoryID"];
			entity.ExtensionTypeId = (Convert.IsDBNull(dataRow["ExtensionTypeID"]))?(int)0:(System.Int32)dataRow["ExtensionTypeID"];
			entity.CustomerCanView = (Convert.IsDBNull(dataRow["CustomerCanView"]))?false:(System.Boolean)dataRow["CustomerCanView"];
			entity.ModeratorCanView = (Convert.IsDBNull(dataRow["ModeratorCanView"]))?false:(System.Boolean)dataRow["ModeratorCanView"];
			entity.CustomerCanEdit = (Convert.IsDBNull(dataRow["CustomerCanEdit"]))?false:(System.Boolean)dataRow["CustomerCanEdit"];
			entity.ModeratorCanEdit = (Convert.IsDBNull(dataRow["ModeratorCanEdit"]))?false:(System.Boolean)dataRow["ModeratorCanEdit"];
			entity.Id = (Convert.IsDBNull(dataRow["id"]))?(int)0:(System.Int32)dataRow["id"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region Vw_SystemExtension_CustomerLabelFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_SystemExtension_CustomerLabel"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_SystemExtension_CustomerLabelFilterBuilder : SqlFilterBuilder<Vw_SystemExtension_CustomerLabelColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_SystemExtension_CustomerLabelFilterBuilder class.
		/// </summary>
		public Vw_SystemExtension_CustomerLabelFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_SystemExtension_CustomerLabelFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_SystemExtension_CustomerLabelFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_SystemExtension_CustomerLabelFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_SystemExtension_CustomerLabelFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_SystemExtension_CustomerLabelFilterBuilder

	#region Vw_SystemExtension_CustomerLabelParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_SystemExtension_CustomerLabel"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_SystemExtension_CustomerLabelParameterBuilder : ParameterizedSqlFilterBuilder<Vw_SystemExtension_CustomerLabelColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_SystemExtension_CustomerLabelParameterBuilder class.
		/// </summary>
		public Vw_SystemExtension_CustomerLabelParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_SystemExtension_CustomerLabelParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_SystemExtension_CustomerLabelParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_SystemExtension_CustomerLabelParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_SystemExtension_CustomerLabelParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_SystemExtension_CustomerLabelParameterBuilder
} // end namespace
