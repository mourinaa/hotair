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
	/// This class is the base class for any <see cref="Vw_SystemExtension_AllProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract class Vw_SystemExtension_AllProviderBaseCore : EntityViewProviderBase<Vw_SystemExtension_All>
	{
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions
		
		/*
		///<summary>
		/// Fill an VList&lt;Vw_SystemExtension_All&gt; From a DataSet
		///</summary>
		/// <param name="dataSet">the DataSet</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList&lt;Vw_SystemExtension_All&gt;"/></returns>
		protected static VList&lt;Vw_SystemExtension_All&gt; Fill(DataSet dataSet, VList<Vw_SystemExtension_All> rows, int start, int pagelen)
		{
			if (dataSet.Tables.Count == 1)
			{
				return Fill(dataSet.Tables[0], rows, start, pagelen);
			}
			else
			{
				return new VList<Vw_SystemExtension_All>();
			}	
		}
		
		
		///<summary>
		/// Fill an VList&lt;Vw_SystemExtension_All&gt; From a DataTable
		///</summary>
		/// <param name="dataTable">the DataTable that hold the data.</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pagelen">number of row.</param>
		///<returns><see chref="VList<Vw_SystemExtension_All>"/></returns>
		protected static VList&lt;Vw_SystemExtension_All&gt; Fill(DataTable dataTable, VList<Vw_SystemExtension_All> rows, int start, int pagelen)
		{
			int recordnum = 0;
			
			System.Collections.IEnumerator dataRows =  dataTable.Rows.GetEnumerator();
			
			while (dataRows.MoveNext() && (pagelen != 0))
			{
				if(recordnum >= start)
				{
					DataRow row = (DataRow)dataRows.Current;
				
					Vw_SystemExtension_All c = new Vw_SystemExtension_All();
					c.CustomerId = (Convert.IsDBNull(row["CustomerID"]))?(int)0:(System.Int32)row["CustomerID"];
					c.SystemExtensionId = (Convert.IsDBNull(row["SystemExtensionID"]))?(int)0:(System.Int32)row["SystemExtensionID"];
					c.ExtensionTypeId = (Convert.IsDBNull(row["ExtensionTypeID"]))?(int)0:(System.Int32)row["ExtensionTypeID"];
					c.ExtensionTypeLabel = (Convert.IsDBNull(row["ExtensionTypeLabel"]))?string.Empty:(System.String)row["ExtensionTypeLabel"];
					c.CustomerCanView = (Convert.IsDBNull(row["CustomerCanView"]))?false:(System.Boolean)row["CustomerCanView"];
					c.ModeratorCanView = (Convert.IsDBNull(row["ModeratorCanView"]))?false:(System.Boolean)row["ModeratorCanView"];
					c.CustomerCanEdit = (Convert.IsDBNull(row["CustomerCanEdit"]))?false:(System.Boolean)row["CustomerCanEdit"];
					c.ModeratorCanEdit = (Convert.IsDBNull(row["ModeratorCanEdit"]))?false:(System.Boolean)row["ModeratorCanEdit"];
					c.TableId = (Convert.IsDBNull(row["TableID"]))?(int)0:(System.Int32)row["TableID"];
					c.ReferenceValue = (Convert.IsDBNull(row["ReferenceValue"]))?string.Empty:(System.String)row["ReferenceValue"];
					c.Name = (Convert.IsDBNull(row["Name"]))?string.Empty:(System.String)row["Name"];
					c.DisplayName = (Convert.IsDBNull(row["DisplayName"]))?string.Empty:(System.String)row["DisplayName"];
					c.CategoryName = (Convert.IsDBNull(row["CategoryName"]))?string.Empty:(System.String)row["CategoryName"];
					c.ExtensionTypeCategoryId = (Convert.IsDBNull(row["ExtensionTypeCategoryID"]))?(int)0:(System.Int32)row["ExtensionTypeCategoryID"];
					c.SystemExtensionLabelId = (Convert.IsDBNull(row["SystemExtensionLabelID"]))?(int)0:(System.Int32)row["SystemExtensionLabelID"];
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
		/// Fill an <see cref="VList&lt;Vw_SystemExtension_All&gt;"/> From a DataReader.
		///</summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Start row</param>
		/// <param name="pageLength">number of row.</param>
		///<returns>a <see cref="VList&lt;Vw_SystemExtension_All&gt;"/></returns>
		protected VList<Vw_SystemExtension_All> Fill(IDataReader reader, VList<Vw_SystemExtension_All> rows, int start, int pageLength)
		{
			int recordnum = 0;
			while (reader.Read() && (pageLength != 0))
			{
				if(recordnum >= start)
				{
					Vw_SystemExtension_All entity = null;
					if (DataRepository.Provider.UseEntityFactory)
					{
						entity = EntityManager.CreateViewEntity<Vw_SystemExtension_All>("Vw_SystemExtension_All",  DataRepository.Provider.EntityCreationalFactoryType); 
					}
					else
					{
						entity = new Vw_SystemExtension_All();
					}
					
					entity.SuppressEntityEvents = true;

					entity.CustomerId = (System.Int32)reader[((int)Vw_SystemExtension_AllColumn.CustomerId)];
					//entity.CustomerId = (Convert.IsDBNull(reader["CustomerID"]))?(int)0:(System.Int32)reader["CustomerID"];
					entity.SystemExtensionId = (System.Int32)reader[((int)Vw_SystemExtension_AllColumn.SystemExtensionId)];
					//entity.SystemExtensionId = (Convert.IsDBNull(reader["SystemExtensionID"]))?(int)0:(System.Int32)reader["SystemExtensionID"];
					entity.ExtensionTypeId = (System.Int32)reader[((int)Vw_SystemExtension_AllColumn.ExtensionTypeId)];
					//entity.ExtensionTypeId = (Convert.IsDBNull(reader["ExtensionTypeID"]))?(int)0:(System.Int32)reader["ExtensionTypeID"];
					entity.ExtensionTypeLabel = (System.String)reader[((int)Vw_SystemExtension_AllColumn.ExtensionTypeLabel)];
					//entity.ExtensionTypeLabel = (Convert.IsDBNull(reader["ExtensionTypeLabel"]))?string.Empty:(System.String)reader["ExtensionTypeLabel"];
					entity.CustomerCanView = (System.Boolean)reader[((int)Vw_SystemExtension_AllColumn.CustomerCanView)];
					//entity.CustomerCanView = (Convert.IsDBNull(reader["CustomerCanView"]))?false:(System.Boolean)reader["CustomerCanView"];
					entity.ModeratorCanView = (System.Boolean)reader[((int)Vw_SystemExtension_AllColumn.ModeratorCanView)];
					//entity.ModeratorCanView = (Convert.IsDBNull(reader["ModeratorCanView"]))?false:(System.Boolean)reader["ModeratorCanView"];
					entity.CustomerCanEdit = (System.Boolean)reader[((int)Vw_SystemExtension_AllColumn.CustomerCanEdit)];
					//entity.CustomerCanEdit = (Convert.IsDBNull(reader["CustomerCanEdit"]))?false:(System.Boolean)reader["CustomerCanEdit"];
					entity.ModeratorCanEdit = (System.Boolean)reader[((int)Vw_SystemExtension_AllColumn.ModeratorCanEdit)];
					//entity.ModeratorCanEdit = (Convert.IsDBNull(reader["ModeratorCanEdit"]))?false:(System.Boolean)reader["ModeratorCanEdit"];
					entity.TableId = (System.Int32)reader[((int)Vw_SystemExtension_AllColumn.TableId)];
					//entity.TableId = (Convert.IsDBNull(reader["TableID"]))?(int)0:(System.Int32)reader["TableID"];
					entity.ReferenceValue = (System.String)reader[((int)Vw_SystemExtension_AllColumn.ReferenceValue)];
					//entity.ReferenceValue = (Convert.IsDBNull(reader["ReferenceValue"]))?string.Empty:(System.String)reader["ReferenceValue"];
					entity.Name = (System.String)reader[((int)Vw_SystemExtension_AllColumn.Name)];
					//entity.Name = (Convert.IsDBNull(reader["Name"]))?string.Empty:(System.String)reader["Name"];
					entity.DisplayName = (System.String)reader[((int)Vw_SystemExtension_AllColumn.DisplayName)];
					//entity.DisplayName = (Convert.IsDBNull(reader["DisplayName"]))?string.Empty:(System.String)reader["DisplayName"];
					entity.CategoryName = (System.String)reader[((int)Vw_SystemExtension_AllColumn.CategoryName)];
					//entity.CategoryName = (Convert.IsDBNull(reader["CategoryName"]))?string.Empty:(System.String)reader["CategoryName"];
					entity.ExtensionTypeCategoryId = (System.Int32)reader[((int)Vw_SystemExtension_AllColumn.ExtensionTypeCategoryId)];
					//entity.ExtensionTypeCategoryId = (Convert.IsDBNull(reader["ExtensionTypeCategoryID"]))?(int)0:(System.Int32)reader["ExtensionTypeCategoryID"];
					entity.SystemExtensionLabelId = (System.Int32)reader[((int)Vw_SystemExtension_AllColumn.SystemExtensionLabelId)];
					//entity.SystemExtensionLabelId = (Convert.IsDBNull(reader["SystemExtensionLabelID"]))?(int)0:(System.Int32)reader["SystemExtensionLabelID"];
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
		/// Refreshes the <see cref="Vw_SystemExtension_All"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="Vw_SystemExtension_All"/> object to refresh.</param>
		protected void RefreshEntity(IDataReader reader, Vw_SystemExtension_All entity)
		{
			reader.Read();
			entity.CustomerId = (System.Int32)reader[((int)Vw_SystemExtension_AllColumn.CustomerId)];
			//entity.CustomerId = (Convert.IsDBNull(reader["CustomerID"]))?(int)0:(System.Int32)reader["CustomerID"];
			entity.SystemExtensionId = (System.Int32)reader[((int)Vw_SystemExtension_AllColumn.SystemExtensionId)];
			//entity.SystemExtensionId = (Convert.IsDBNull(reader["SystemExtensionID"]))?(int)0:(System.Int32)reader["SystemExtensionID"];
			entity.ExtensionTypeId = (System.Int32)reader[((int)Vw_SystemExtension_AllColumn.ExtensionTypeId)];
			//entity.ExtensionTypeId = (Convert.IsDBNull(reader["ExtensionTypeID"]))?(int)0:(System.Int32)reader["ExtensionTypeID"];
			entity.ExtensionTypeLabel = (System.String)reader[((int)Vw_SystemExtension_AllColumn.ExtensionTypeLabel)];
			//entity.ExtensionTypeLabel = (Convert.IsDBNull(reader["ExtensionTypeLabel"]))?string.Empty:(System.String)reader["ExtensionTypeLabel"];
			entity.CustomerCanView = (System.Boolean)reader[((int)Vw_SystemExtension_AllColumn.CustomerCanView)];
			//entity.CustomerCanView = (Convert.IsDBNull(reader["CustomerCanView"]))?false:(System.Boolean)reader["CustomerCanView"];
			entity.ModeratorCanView = (System.Boolean)reader[((int)Vw_SystemExtension_AllColumn.ModeratorCanView)];
			//entity.ModeratorCanView = (Convert.IsDBNull(reader["ModeratorCanView"]))?false:(System.Boolean)reader["ModeratorCanView"];
			entity.CustomerCanEdit = (System.Boolean)reader[((int)Vw_SystemExtension_AllColumn.CustomerCanEdit)];
			//entity.CustomerCanEdit = (Convert.IsDBNull(reader["CustomerCanEdit"]))?false:(System.Boolean)reader["CustomerCanEdit"];
			entity.ModeratorCanEdit = (System.Boolean)reader[((int)Vw_SystemExtension_AllColumn.ModeratorCanEdit)];
			//entity.ModeratorCanEdit = (Convert.IsDBNull(reader["ModeratorCanEdit"]))?false:(System.Boolean)reader["ModeratorCanEdit"];
			entity.TableId = (System.Int32)reader[((int)Vw_SystemExtension_AllColumn.TableId)];
			//entity.TableId = (Convert.IsDBNull(reader["TableID"]))?(int)0:(System.Int32)reader["TableID"];
			entity.ReferenceValue = (System.String)reader[((int)Vw_SystemExtension_AllColumn.ReferenceValue)];
			//entity.ReferenceValue = (Convert.IsDBNull(reader["ReferenceValue"]))?string.Empty:(System.String)reader["ReferenceValue"];
			entity.Name = (System.String)reader[((int)Vw_SystemExtension_AllColumn.Name)];
			//entity.Name = (Convert.IsDBNull(reader["Name"]))?string.Empty:(System.String)reader["Name"];
			entity.DisplayName = (System.String)reader[((int)Vw_SystemExtension_AllColumn.DisplayName)];
			//entity.DisplayName = (Convert.IsDBNull(reader["DisplayName"]))?string.Empty:(System.String)reader["DisplayName"];
			entity.CategoryName = (System.String)reader[((int)Vw_SystemExtension_AllColumn.CategoryName)];
			//entity.CategoryName = (Convert.IsDBNull(reader["CategoryName"]))?string.Empty:(System.String)reader["CategoryName"];
			entity.ExtensionTypeCategoryId = (System.Int32)reader[((int)Vw_SystemExtension_AllColumn.ExtensionTypeCategoryId)];
			//entity.ExtensionTypeCategoryId = (Convert.IsDBNull(reader["ExtensionTypeCategoryID"]))?(int)0:(System.Int32)reader["ExtensionTypeCategoryID"];
			entity.SystemExtensionLabelId = (System.Int32)reader[((int)Vw_SystemExtension_AllColumn.SystemExtensionLabelId)];
			//entity.SystemExtensionLabelId = (Convert.IsDBNull(reader["SystemExtensionLabelID"]))?(int)0:(System.Int32)reader["SystemExtensionLabelID"];
			reader.Close();
	
			entity.AcceptChanges();
		}
		
		/*
		/// <summary>
		/// Refreshes the <see cref="Vw_SystemExtension_All"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="Vw_SystemExtension_All"/> object.</param>
		protected static void RefreshEntity(DataSet dataSet, Vw_SystemExtension_All entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.CustomerId = (Convert.IsDBNull(dataRow["CustomerID"]))?(int)0:(System.Int32)dataRow["CustomerID"];
			entity.SystemExtensionId = (Convert.IsDBNull(dataRow["SystemExtensionID"]))?(int)0:(System.Int32)dataRow["SystemExtensionID"];
			entity.ExtensionTypeId = (Convert.IsDBNull(dataRow["ExtensionTypeID"]))?(int)0:(System.Int32)dataRow["ExtensionTypeID"];
			entity.ExtensionTypeLabel = (Convert.IsDBNull(dataRow["ExtensionTypeLabel"]))?string.Empty:(System.String)dataRow["ExtensionTypeLabel"];
			entity.CustomerCanView = (Convert.IsDBNull(dataRow["CustomerCanView"]))?false:(System.Boolean)dataRow["CustomerCanView"];
			entity.ModeratorCanView = (Convert.IsDBNull(dataRow["ModeratorCanView"]))?false:(System.Boolean)dataRow["ModeratorCanView"];
			entity.CustomerCanEdit = (Convert.IsDBNull(dataRow["CustomerCanEdit"]))?false:(System.Boolean)dataRow["CustomerCanEdit"];
			entity.ModeratorCanEdit = (Convert.IsDBNull(dataRow["ModeratorCanEdit"]))?false:(System.Boolean)dataRow["ModeratorCanEdit"];
			entity.TableId = (Convert.IsDBNull(dataRow["TableID"]))?(int)0:(System.Int32)dataRow["TableID"];
			entity.ReferenceValue = (Convert.IsDBNull(dataRow["ReferenceValue"]))?string.Empty:(System.String)dataRow["ReferenceValue"];
			entity.Name = (Convert.IsDBNull(dataRow["Name"]))?string.Empty:(System.String)dataRow["Name"];
			entity.DisplayName = (Convert.IsDBNull(dataRow["DisplayName"]))?string.Empty:(System.String)dataRow["DisplayName"];
			entity.CategoryName = (Convert.IsDBNull(dataRow["CategoryName"]))?string.Empty:(System.String)dataRow["CategoryName"];
			entity.ExtensionTypeCategoryId = (Convert.IsDBNull(dataRow["ExtensionTypeCategoryID"]))?(int)0:(System.Int32)dataRow["ExtensionTypeCategoryID"];
			entity.SystemExtensionLabelId = (Convert.IsDBNull(dataRow["SystemExtensionLabelID"]))?(int)0:(System.Int32)dataRow["SystemExtensionLabelID"];
			entity.AcceptChanges();
		}
		*/
			
		#endregion Helper Functions
	}//end class

	#region Vw_SystemExtension_AllFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_SystemExtension_All"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_SystemExtension_AllFilterBuilder : SqlFilterBuilder<Vw_SystemExtension_AllColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_SystemExtension_AllFilterBuilder class.
		/// </summary>
		public Vw_SystemExtension_AllFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_SystemExtension_AllFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_SystemExtension_AllFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_SystemExtension_AllFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_SystemExtension_AllFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_SystemExtension_AllFilterBuilder

	#region Vw_SystemExtension_AllParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;EntityColumn&gt;"/> class
	/// that is used exclusively with a <see cref="Vw_SystemExtension_All"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class Vw_SystemExtension_AllParameterBuilder : ParameterizedSqlFilterBuilder<Vw_SystemExtension_AllColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the Vw_SystemExtension_AllParameterBuilder class.
		/// </summary>
		public Vw_SystemExtension_AllParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the Vw_SystemExtension_AllParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public Vw_SystemExtension_AllParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the Vw_SystemExtension_AllParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public Vw_SystemExtension_AllParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion Vw_SystemExtension_AllParameterBuilder
} // end namespace
