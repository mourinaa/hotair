#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using CONFDB.Entities;
using CONFDB.Data;

#endregion

namespace CONFDB.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="ForExProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class ForExProviderBaseCore : EntityProviderBase<CONFDB.Entities.ForEx, CONFDB.Entities.ForExKey>
	{		
		#region Get from Many To Many Relationship Functions
		#endregion	
		
		#region Delete Methods

		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to delete.</param>
		/// <returns>Returns true if operation suceeded.</returns>
		public override bool Delete(TransactionManager transactionManager, CONFDB.Entities.ForExKey key)
		{
			return Delete(transactionManager, key.Id);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="_id">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public bool Delete(System.Int32 _id)
		{
			return Delete(null, _id);
		}
		
		/// <summary>
		/// 	Deletes a row from the DataSource.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id">. Primary Key.</param>
		/// <remarks>Deletes based on primary key(s).</remarks>
		/// <returns>Returns true if operation suceeded.</returns>
		public abstract bool Delete(TransactionManager transactionManager, System.Int32 _id);		
		
		#endregion Delete Methods
		
		#region Get By Foreign Key Functions
	
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ForEx_Curve key.
		///		FK_ForEx_Curve Description: 
		/// </summary>
		/// <param name="_curveId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.ForEx objects.</returns>
		public CONFDB.Entities.TList<ForEx> GetByCurveId(System.Int32 _curveId)
		{
			int count = -1;
			return GetByCurveId(_curveId, 0,int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ForEx_Curve key.
		///		FK_ForEx_Curve Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_curveId"></param>
		/// <returns>Returns a typed collection of CONFDB.Entities.ForEx objects.</returns>
		/// <remarks></remarks>
		public CONFDB.Entities.TList<ForEx> GetByCurveId(TransactionManager transactionManager, System.Int32 _curveId)
		{
			int count = -1;
			return GetByCurveId(transactionManager, _curveId, 0, int.MaxValue, out count);
		}
		
			/// <summary>
		/// 	Gets rows from the datasource based on the FK_ForEx_Curve key.
		///		FK_ForEx_Curve Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_curveId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		///  <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.ForEx objects.</returns>
		public CONFDB.Entities.TList<ForEx> GetByCurveId(TransactionManager transactionManager, System.Int32 _curveId, int start, int pageLength)
		{
			int count = -1;
			return GetByCurveId(transactionManager, _curveId, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ForEx_Curve key.
		///		fk_ForEx_Curve Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_curveId"></param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.ForEx objects.</returns>
		public CONFDB.Entities.TList<ForEx> GetByCurveId(System.Int32 _curveId, int start, int pageLength)
		{
			int count =  -1;
			return GetByCurveId(null, _curveId, start, pageLength,out count);	
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ForEx_Curve key.
		///		fk_ForEx_Curve Description: 
		/// </summary>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="_curveId"></param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns a typed collection of CONFDB.Entities.ForEx objects.</returns>
		public CONFDB.Entities.TList<ForEx> GetByCurveId(System.Int32 _curveId, int start, int pageLength,out int count)
		{
			return GetByCurveId(null, _curveId, start, pageLength, out count);	
		}
						
		/// <summary>
		/// 	Gets rows from the datasource based on the FK_ForEx_Curve key.
		///		FK_ForEx_Curve Description: 
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_curveId"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns a typed collection of CONFDB.Entities.ForEx objects.</returns>
		public abstract CONFDB.Entities.TList<ForEx> GetByCurveId(TransactionManager transactionManager, System.Int32 _curveId, int start, int pageLength, out int count);
		
		#endregion

		#region Get By Index Functions
		
		/// <summary>
		/// 	Gets a row from the DataSource based on its primary key.
		/// </summary>
		/// <param name="transactionManager">A <see cref="TransactionManager"/> object.</param>
		/// <param name="key">The unique identifier of the row to retrieve.</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <returns>Returns an instance of the Entity class.</returns>
		public override CONFDB.Entities.ForEx Get(TransactionManager transactionManager, CONFDB.Entities.ForExKey key, int start, int pageLength)
		{
			return GetById(transactionManager, key.Id, start, pageLength);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the primary key ForEx_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ForEx"/> class.</returns>
		public CONFDB.Entities.ForEx GetById(System.Int32 _id)
		{
			int count = -1;
			return GetById(null,_id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ForEx_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ForEx"/> class.</returns>
		public CONFDB.Entities.ForEx GetById(System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(null, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ForEx_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ForEx"/> class.</returns>
		public CONFDB.Entities.ForEx GetById(TransactionManager transactionManager, System.Int32 _id)
		{
			int count = -1;
			return GetById(transactionManager, _id, 0, int.MaxValue, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ForEx_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ForEx"/> class.</returns>
		public CONFDB.Entities.ForEx GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength)
		{
			int count = -1;
			return GetById(transactionManager, _id, start, pageLength, out count);
		}
		
		/// <summary>
		/// 	Gets rows from the datasource based on the ForEx_PK index.
		/// </summary>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">out parameter to get total records for query</param>
		/// <remarks></remarks>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ForEx"/> class.</returns>
		public CONFDB.Entities.ForEx GetById(System.Int32 _id, int start, int pageLength, out int count)
		{
			return GetById(null, _id, start, pageLength, out count);
		}
		
				
		/// <summary>
		/// 	Gets rows from the datasource based on the ForEx_PK index.
		/// </summary>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="_id"></param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">Number of rows to return.</param>
		/// <param name="count">The total number of records.</param>
		/// <returns>Returns an instance of the <see cref="CONFDB.Entities.ForEx"/> class.</returns>
		public abstract CONFDB.Entities.ForEx GetById(TransactionManager transactionManager, System.Int32 _id, int start, int pageLength, out int count);
						
		#endregion "Get By Index Functions"
	
		#region Custom Methods
		
		
		#endregion

		#region Helper Functions	
		
		/// <summary>
		/// Fill a CONFDB.Entities.TList&lt;ForEx&gt; From a DataReader.
		/// </summary>
		/// <param name="reader">Datareader</param>
		/// <param name="rows">The collection to fill</param>
		/// <param name="start">Row number at which to start reading, the first row is 0.</param>
		/// <param name="pageLength">number of rows.</param>
		/// <returns>a <see cref="CONFDB.Entities.TList&lt;ForEx&gt;"/></returns>
		public static CONFDB.Entities.TList<ForEx> Fill(IDataReader reader, CONFDB.Entities.TList<ForEx> rows, int start, int pageLength)
		{
			NetTiersProvider currentProvider = DataRepository.Provider;
            bool useEntityFactory = currentProvider.UseEntityFactory;
            bool enableEntityTracking = currentProvider.EnableEntityTracking;
            LoadPolicy currentLoadPolicy = currentProvider.CurrentLoadPolicy;
			
			// advance to the starting row
			for (int i = 0; i < start; i++)
			{
				if (!reader.Read())
				return rows; // not enough rows, just return
			}
			for (int i = 0; i < pageLength; i++)
			{
				if (!reader.Read())
					break; // we are done
					
				string key = null;
				
				CONFDB.Entities.ForEx c = null;
				if (useEntityFactory)
				{
					key = new System.Text.StringBuilder("ForEx")
					.Append("|").Append((reader.IsDBNull(((int)CONFDB.Entities.ForExColumn.Id - 1))?(int)0:(System.Int32)reader[((int)CONFDB.Entities.ForExColumn.Id - 1)]).ToString()).ToString();
					c = EntityManager.LocateOrCreate<ForEx>(
					key.ToString(), // EntityTrackingKey
					"ForEx",  //Creational Type
					currentProvider.EntityCreationalFactoryType,  //Factory used to create entity
					currentProvider.EnableEntityTracking); // Track this entity?
				}
				else
				{
					c = new CONFDB.Entities.ForEx();
				}
				
				if (!enableEntityTracking ||
					c.EntityState == EntityState.Added ||
					(enableEntityTracking &&
						(
							(currentLoadPolicy == LoadPolicy.PreserveChanges && c.EntityState == EntityState.Unchanged) ||
							(currentLoadPolicy == LoadPolicy.DiscardChanges && (c.EntityState == EntityState.Unchanged || c.EntityState == EntityState.Changed))
						)
					))
				{
					c.SuppressEntityEvents = true;
					c.Id = (System.Int32)reader[((int)ForExColumn.Id - 1)];
					c.OriginalId = c.Id;
					c.FromCcy = (System.String)reader[((int)ForExColumn.FromCcy - 1)];
					c.ToCcy = (System.String)reader[((int)ForExColumn.ToCcy - 1)];
					c.Rate = (System.Decimal)reader[((int)ForExColumn.Rate - 1)];
					c.CurveId = (System.Int32)reader[((int)ForExColumn.CurveId - 1)];
					c.EffectiveDate = (System.DateTime)reader[((int)ForExColumn.EffectiveDate - 1)];
					c.EntityTrackingKey = key;
					c.AcceptChanges();
					c.SuppressEntityEvents = false;
				}
				rows.Add(c);
			}
		return rows;
		}		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.ForEx"/> object from the <see cref="IDataReader"/>.
		/// </summary>
		/// <param name="reader">The <see cref="IDataReader"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.ForEx"/> object to refresh.</param>
		public static void RefreshEntity(IDataReader reader, CONFDB.Entities.ForEx entity)
		{
			if (!reader.Read()) return;
			
			entity.Id = (System.Int32)reader[((int)ForExColumn.Id - 1)];
			entity.OriginalId = (System.Int32)reader["ID"];
			entity.FromCcy = (System.String)reader[((int)ForExColumn.FromCcy - 1)];
			entity.ToCcy = (System.String)reader[((int)ForExColumn.ToCcy - 1)];
			entity.Rate = (System.Decimal)reader[((int)ForExColumn.Rate - 1)];
			entity.CurveId = (System.Int32)reader[((int)ForExColumn.CurveId - 1)];
			entity.EffectiveDate = (System.DateTime)reader[((int)ForExColumn.EffectiveDate - 1)];
			entity.AcceptChanges();
		}
		
		/// <summary>
		/// Refreshes the <see cref="CONFDB.Entities.ForEx"/> object from the <see cref="DataSet"/>.
		/// </summary>
		/// <param name="dataSet">The <see cref="DataSet"/> to read from.</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.ForEx"/> object.</param>
		public static void RefreshEntity(DataSet dataSet, CONFDB.Entities.ForEx entity)
		{
			DataRow dataRow = dataSet.Tables[0].Rows[0];
			
			entity.Id = (System.Int32)dataRow["ID"];
			entity.OriginalId = (System.Int32)dataRow["ID"];
			entity.FromCcy = (System.String)dataRow["FromCcy"];
			entity.ToCcy = (System.String)dataRow["ToCcy"];
			entity.Rate = (System.Decimal)dataRow["Rate"];
			entity.CurveId = (System.Int32)dataRow["CurveID"];
			entity.EffectiveDate = (System.DateTime)dataRow["EffectiveDate"];
			entity.AcceptChanges();
		}
		#endregion 
		
		#region DeepLoad Methods
		/// <summary>
		/// Deep Loads the <see cref="IEntity"/> object with criteria based of the child 
		/// property collections only N Levels Deep based on the <see cref="DeepLoadType"/>.
		/// </summary>
		/// <remarks>
		/// Use this method with caution as it is possible to DeepLoad with Recursion and traverse an entire object graph.
		/// </remarks>
		/// <param name="transactionManager"><see cref="TransactionManager"/> object</param>
		/// <param name="entity">The <see cref="CONFDB.Entities.ForEx"/> object to load.</param>
		/// <param name="deep">Boolean. A flag that indicates whether to recursively save all Property Collection that are descendants of this instance. If True, saves the complete object graph below this object. If False, saves this object only. </param>
		/// <param name="deepLoadType">DeepLoadType Enumeration to Include/Exclude object property collections from Load.</param>
		/// <param name="childTypes">CONFDB.Entities.ForEx Property Collection Type Array To Include or Exclude from Load</param>
		/// <param name="innerList">A collection of child types for easy access.</param>
	    /// <exception cref="ArgumentNullException">entity or childTypes is null.</exception>
	    /// <exception cref="ArgumentException">deepLoadType has invalid value.</exception>
		internal override void DeepLoad(TransactionManager transactionManager, CONFDB.Entities.ForEx entity, bool deep, DeepLoadType deepLoadType, System.Type[] childTypes, DeepSession innerList)
		{
			if(entity == null)
				return;

			#region CurveIdSource	
			if (CanDeepLoad(entity, "Curve|CurveIdSource", deepLoadType, innerList) 
				&& entity.CurveIdSource == null)
			{
				object[] pkItems = new object[1];
				pkItems[0] = entity.CurveId;
				Curve tmpEntity = EntityManager.LocateEntity<Curve>(EntityLocator.ConstructKeyFromPkItems(typeof(Curve), pkItems), DataRepository.Provider.EnableEntityTracking);
				if (tmpEntity != null)
					entity.CurveIdSource = tmpEntity;
				else
					entity.CurveIdSource = DataRepository.CurveProvider.GetById(transactionManager, entity.CurveId);		
				
				#if NETTIERS_DEBUG
				System.Diagnostics.Debug.WriteLine("- property 'CurveIdSource' loaded. key " + entity.EntityTrackingKey);
				#endif 
				
				if (deep && entity.CurveIdSource != null)
				{
					innerList.SkipChildren = true;
					DataRepository.CurveProvider.DeepLoad(transactionManager, entity.CurveIdSource, deep, deepLoadType, childTypes, innerList);
					innerList.SkipChildren = false;
				}
					
			}
			#endregion CurveIdSource
			
			//used to hold DeepLoad method delegates and fire after all the local children have been loaded.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			
			//Fire all DeepLoad Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			deepHandles = null;
		}
		
		#endregion 
		
		#region DeepSave Methods

		/// <summary>
		/// Deep Save the entire object graph of the CONFDB.Entities.ForEx object with criteria based of the child 
		/// Type property array and DeepSaveType.
		/// </summary>
		/// <param name="transactionManager">The transaction manager.</param>
		/// <param name="entity">CONFDB.Entities.ForEx instance</param>
		/// <param name="deepSaveType">DeepSaveType Enumeration to Include/Exclude object property collections from Save.</param>
		/// <param name="childTypes">CONFDB.Entities.ForEx Property Collection Type Array To Include or Exclude from Save</param>
		/// <param name="innerList">A Hashtable of child types for easy access.</param>
		internal override bool DeepSave(TransactionManager transactionManager, CONFDB.Entities.ForEx entity, DeepSaveType deepSaveType, System.Type[] childTypes, DeepSession innerList)
		{	
			if (entity == null)
				return false;
							
			#region Composite Parent Properties
			//Save Source Composite Properties, however, don't call deep save on them.  
			//So they only get saved a single level deep.
			
			#region CurveIdSource
			if (CanDeepSave(entity, "Curve|CurveIdSource", deepSaveType, innerList) 
				&& entity.CurveIdSource != null)
			{
				DataRepository.CurveProvider.Save(transactionManager, entity.CurveIdSource);
				entity.CurveId = entity.CurveIdSource.Id;
			}
			#endregion 
			#endregion Composite Parent Properties

			// Save Root Entity through Provider
			if (!entity.IsDeleted)
				this.Save(transactionManager, entity);
			
			//used to hold DeepSave method delegates and fire after all the local children have been saved.
			Dictionary<string, KeyValuePair<Delegate, object>> deepHandles = new Dictionary<string, KeyValuePair<Delegate, object>>();
			//Fire all DeepSave Items
			foreach(KeyValuePair<Delegate, object> pair in deepHandles.Values)
		    {
                pair.Key.DynamicInvoke((object[])pair.Value);
		    }
			
			// Save Root Entity through Provider, if not already saved in delete mode
			if (entity.IsDeleted)
				this.Save(transactionManager, entity);
				

			deepHandles = null;
						
			return true;
		}
		#endregion
	} // end class
	
	#region ForExChildEntityTypes
	
	///<summary>
	/// Enumeration used to expose the different child entity types 
	/// for child properties in <c>CONFDB.Entities.ForEx</c>
	///</summary>
	public enum ForExChildEntityTypes
	{
		
		///<summary>
		/// Composite Property for <c>Curve</c> at CurveIdSource
		///</summary>
		[ChildEntityType(typeof(Curve))]
		Curve,
		}
	
	#endregion ForExChildEntityTypes
	
	#region ForExFilterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="SqlFilterBuilder&lt;ForExColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ForEx"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ForExFilterBuilder : SqlFilterBuilder<ForExColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ForExFilterBuilder class.
		/// </summary>
		public ForExFilterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ForExFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ForExFilterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ForExFilterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ForExFilterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ForExFilterBuilder
	
	#region ForExParameterBuilder
	
	/// <summary>
	/// A strongly-typed instance of the <see cref="ParameterizedSqlFilterBuilder&lt;ForExColumn&gt;"/> class
	/// that is used exclusively with a <see cref="ForEx"/> object.
	/// </summary>
	[CLSCompliant(true)]
	public class ForExParameterBuilder : ParameterizedSqlFilterBuilder<ForExColumn>
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the ForExParameterBuilder class.
		/// </summary>
		public ForExParameterBuilder() : base() { }

		/// <summary>
		/// Initializes a new instance of the ForExParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		public ForExParameterBuilder(bool ignoreCase) : base(ignoreCase) { }

		/// <summary>
		/// Initializes a new instance of the ForExParameterBuilder class.
		/// </summary>
		/// <param name="ignoreCase">Specifies whether to create case-insensitive statements.</param>
		/// <param name="useAnd">Specifies whether to combine statements using AND or OR.</param>
		public ForExParameterBuilder(bool ignoreCase, bool useAnd) : base(ignoreCase, useAnd) { }

		#endregion Constructors
	}

	#endregion ForExParameterBuilder
} // end namespace
