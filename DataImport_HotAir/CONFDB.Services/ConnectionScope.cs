﻿#region Using Directives
using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Threading;
using System.Web;

using CONFDB.Entities;
using CONFDB.Data;
using CONFDB.Data.Bases;

using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
#endregion 

namespace CONFDB.Services
{
	/// <summary>
	/// Provides storage of global database connection information.
	/// </summary>
	[CLSCompliant(true)]
	public class ConnectionScope : IDisposable
	{
		private static readonly string Key = "CONFDB.Services.ConnectionScope";
		private  bool disposed;
        private static object syncRoot = new object(); 
		
		/// <summary>
		/// Initializes a new instance of the ConnectionScope class.
		/// </summary>
		private ConnectionScope()
		{
		}

		/// <summary>
		/// Gets a reference to the ConnectionScope object for the current thread.
		/// </summary>
		public static ConnectionScope Current
		{
			get
			{
				ConnectionScope scope = null;

				if ( HttpContext.Current != null )
				{
					scope = HttpContext.Current.Items[Key] as ConnectionScope;

					if ( scope == null )
					{
						scope = new ConnectionScope();
						HttpContext.Current.Items[Key] = scope;
					}
				}
				else
				{
					LocalDataStoreSlot slot = Thread.GetNamedDataSlot(Key);
					scope = Thread.GetData(slot) as ConnectionScope;

					if ( scope == null )
					{
						scope = new ConnectionScope();
						Thread.SetData(slot, scope);
					}
				}

				return scope;
			}
		}

		#region Helper Methods

		/// <summary>
		/// Creates a new <see cref="Thread"/> object and copies
		/// the current <see cref="ConnectionScope"/> parameters.
		/// </summary>
		/// <param name="start">A delegate specifying which method to run
		/// when the <see cref="Thread"/> is started.</param>
		/// <returns>Returns a new <see cref="Thread"/> object.</returns>
		public static Thread NewThread(ThreadStart start)
		{
			ConnectionScope scope = ConnectionScope.Current;

			Thread t = new Thread(delegate()
			{
				ConnectionScope.Copy(scope);
				start();
			});

			return t;
		}

		/// <summary>
		/// Creates a new <see cref="Thread"/> object and copies
		/// the current <see cref="ConnectionScope"/> parameters.
		/// </summary>
		/// <param name="start">A delegate specifying which method to run
		/// when the <see cref="Thread"/> is started.</param>
		/// <returns>Returns a new <see cref="Thread"/> object.</returns>
		public static Thread NewThread(ParameterizedThreadStart start)
		{
			ConnectionScope scope = ConnectionScope.Current;

			Thread t = new Thread(delegate(Object obj)
			{
				ConnectionScope.Copy(scope);
				start(obj);
			});

			return t;
		}

		/// <summary>
		/// Queues a method for execution. The method executes
		/// when a thread pool thread becomes available.
		/// </summary>
		/// <param name="start">A delegate specifying which method to run
		/// when the <see cref="Thread"/> is started.</param>
		/// <returns>Returns true if the method is successfully queued.</returns>
		public static bool EnqueueOnThreadPool(ThreadStart start)
		{
			ConnectionScope scope = ConnectionScope.Current;

			return ThreadPool.QueueUserWorkItem(delegate(object state)
			{
				ConnectionScope.Copy(scope);
				start();
			}, null);
		}

		/// <summary>
		/// Queues a method for execution. The method executes
		/// when a thread pool thread becomes available.
		/// </summary>
		/// <param name="start">A delegate specifying which method to run
		/// when the <see cref="Thread"/> is started.</param>
		/// <param name="state">An object containing data to be used by the method.</param>
		/// <returns>Returns true if the method is successfully queued.</returns>
		public static bool EnqueueOnThreadPool(ParameterizedThreadStart start, object state)
		{
			ConnectionScope scope = ConnectionScope.Current;

			return ThreadPool.QueueUserWorkItem(delegate(object originalState)
			{
				ConnectionScope.Copy(scope);
				start(originalState);
			}, state);
		}

		/// <summary>
		/// Copies the values from the specified <paramref name="scope"/> object
		/// to the <see cref="ConnectionScope"/> used by the current thread.
		/// </summary>
		/// <param name="scope">A <see cref="ConnectionScope"/> object.</param>
		private static void Copy(ConnectionScope scope)
		{
			ConnectionScope newScope = ConnectionScope.Current;
			newScope.ConnectionStringKey = scope.ConnectionStringKey;
			newScope.DynamicConnectionString = scope.DynamicConnectionString;
            newScope.TransactionManager = scope.TransactionManager;
            newScope.DataProvider = scope.DataProvider;
		}

		/// <summary>
		/// Validates an existing <c cref="TransactionManager" /> if one exists,
		/// otherwise creates a new <c cref="TransactionManager" /> to use.
		/// </summary>
		public static TransactionManager ValidateOrCreateTransaction()
		{
			return ValidateOrCreateTransaction(true);
		}
		
		/// <summary>
		/// Validates an existing <c cref="TransactionManager" /> if one exists,
		/// otherwise creates a new <c cref="TransactionManager" /> to use.
		/// </summary>
		/// <param name="createTransaction">determines whether to create a new transaction</param>
		public static TransactionManager ValidateOrCreateTransaction(bool createTransaction)
		{
			TransactionManager transactionManager = Current.TransactionManager;
			bool isBorrowedTransaction = (transactionManager != null && transactionManager.IsOpen);
			NetTiersProvider dataProvider = Current.DataProvider;
			
			if (isBorrowedTransaction && !dataProvider.IsTransactionSupported)
			{
				if (transactionManager != null)
					throw new Exception("Transaction Support is not included with the current DataRepository provider.  If using a provider that doesn't support transactions, such as a webservice, you should turn off transaction management.");
			}
			else if (isBorrowedTransaction && dataProvider.IsTransactionSupported)
			{
				if (transactionManager == null || !transactionManager.IsOpen )
					throw new ArgumentException("The transactionManager is in an invalid state for this method.  \nYou must begin the tranasction prior to using this method.");

			}
			else if (createTransaction && !isBorrowedTransaction && dataProvider.IsTransactionSupported)
			{
				transactionManager = CreateTransaction();
			}
			else if ( !createTransaction && !isBorrowedTransaction )
			{
				// if current transaction is not valid, but we don't require one, return null
				transactionManager = null;
			}
			
			return transactionManager;
		}
		
		/// <summary>
		/// Creates a new transaction on the current <c>ConnectionScope</c>.
		/// </summary>
		public static TransactionManager CreateTransaction()
		{
			return CreateTransaction(IsolationLevel.ReadCommitted);
		}
		
		/// <summary>
		/// Creates a new transaction on the current <c>ConnectionScope</c>
		/// with the specified <c cref="System.Data.IsolationLevel" />.
		/// </summary>
		/// <param name="level">Determines which <c cref="System.Data.IsolationLevel" /> to use for the transaction.</param>
		public static TransactionManager CreateTransaction(IsolationLevel level)
		{
			Current.TransactionManager = Current.DataProvider.CreateTransaction();
			Current.TransactionManager.BeginTransaction(level);
			return Current.TransactionManager;
		}
		
		/// <summary>
        /// Completes this unit of work instance of the current transaction.  
        /// Commits the transaction,  Cleans up Connection, 
        /// Disposes of TransactionManager which performs unmanaged cleanup.
        /// </summary>
        /// <example>
        ///     try
        ///     {
        ///         using (ConnectionScope.CreateTransaction())
        ///         {
        ///             // or use ConnectionScope.ValidateOrCreateTransaction(true) 
        ///             // if you prefer to dynamically check for an existing transaction
        ///             AccountService.Save(account);
        ///             LedgerService.Save(generalEntry);
        /// 
        ///             //Commit and Cleanup your transaction
        ///             bool result = ConnectionScope.Complete();
        ///         }
        ///     }
        ///     catch (Exception ex)
        ///     {
        ///         // when creating the transaction via the 
        ///         // using (ConnectionScope.CreateTransaction()) construct, 
        ///         // there's no need to rollback, handled by 
        ///         // ConnectionScope Dispose Method.
        /// 
        ///         Logger.Write(ex.Message);
        ///     }
        ///</example>
        public static bool Complete()
        {
            if (Current.disposed)
                throw new ObjectDisposedException("ConnectionScope");

            lock (syncRoot)
            {
                if (Current.HasTransaction)
                {
                    Current.TransactionManager.Commit();
					return true;
                }
				
				return false;
            }
        }
		

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (!disposed)
            {
                lock (syncRoot)
                {
                    disposed = true;

                    if (Current.HasTransaction)
                    {
                        Current.TransactionManager.Rollback();
                    }
                }
            }
        }

		#endregion Helper Methods

		#region Properties

		/// <summary>
		/// The ConnectionStringKey member variable.
		/// </summary>
		private string connectionStringKey;

		/// <summary>
		/// Gets or sets the ConnectionStringKey property.
		/// </summary>
		public string ConnectionStringKey
		{
			get { return connectionStringKey; }
			set { connectionStringKey = value; }
		}

		/// <summary>
		/// The DynamicConnectionString member variable.
		/// </summary>
		private string dynamicConnectionString;

		/// <summary>
		/// Gets or sets the DynamicConnectionString property.
		/// </summary>
		public string DynamicConnectionString
		{
			get { return dynamicConnectionString; }
			set { dynamicConnectionString = value; }
		}

		/// <summary>
		/// The TransactionManager member variable.
		/// </summary>
		private TransactionManager transactionManager;

		/// <summary>
		/// Gets or sets the TransactionManager property.
		/// </summary>
		public TransactionManager TransactionManager
		{
			get { return transactionManager; }
			set { transactionManager = value; }
		}
		
		/// <summary>
		/// The NetTiersProvider member variable.
		/// </summary>
		private NetTiersProvider dataProvider;
		
		/// <summary>
		/// Gets or Sets the Current DataProvider property of the <c>ConnectionScope</c> Object.
		/// </summary>
		/// <remarks>
		/// To use a dynamic connection, you must set both the 
		/// DynamicConnectionString and a unique ConnectionStringKey properties;
		///</remarks>
		public NetTiersProvider DataProvider
		{
			get
			{
				if (dataProvider == null)
				{
					if (string.IsNullOrEmpty(connectionStringKey))
					{
						dataProvider = DataRepository.Provider;
					}
					else if (!DataRepository.Connections.ContainsKey(connectionStringKey) && dynamicConnectionString != null)
					{
						DataRepository.AddConnection(connectionStringKey, dynamicConnectionString);
						dataProvider = DataRepository.Connections[connectionStringKey].Provider;
					}
					else if (DataRepository.Connections.ContainsKey(connectionStringKey)) 
					{
						dataProvider =  DataRepository.Connections[connectionStringKey].Provider;
					}
				}
					
				return dataProvider;
			}
			set
			{
				if (value != null)
				{
					dataProvider = value;	
				}
			}
		}

		/// <summary>
		/// Determines if Current Connections is in a Transaction.
		/// </summary>
		public bool HasTransaction
		{
			get { return Current.TransactionManager != null && Current.TransactionManager.IsOpen; }
		}
		#endregion Properties
	}

}