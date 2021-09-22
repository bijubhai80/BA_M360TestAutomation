using Oracle.DataAccess.Client;
using System;
using System.Configuration;
using System.Data;
using System.Threading;

namespace M360TestAutomation.Oracle
{
    class OracleDB
    {
        public static string CONNECTION_STRING = string.Format("Data Source={0}; User Id={1}; Password={2}", ConfigurationManager.AppSettings.Get("env"), ConfigurationManager.AppSettings.Get("user"), ConfigurationManager.AppSettings.Get("PolicyPassword"));

        private static OracleConnection _connection;
        private static readonly object _connectionLock = new object();

        static OracleDB()
        {
            // Ensure we close our connection when our process exits.
            AppDomain.CurrentDomain.ProcessExit += (sender, args) => _connection?.Close();
        }

        public static OracleConnection GetConnection()
        {
            if (_connection == null)
            {
                lock (_connectionLock)
                {
                    _connection = _connection ?? new OracleConnection(CONNECTION_STRING);
                }
            }

            if (_connection.State == ConnectionState.Closed || _connection.State == ConnectionState.Broken)
            {
                lock (_connectionLock)
                {
                    if (_connection.State == ConnectionState.Closed || _connection.State == ConnectionState.Broken)
                    {
                        _connection.Open();
                    }
                }
            }

            var retryCount = 0;
            while (_connection.State == ConnectionState.Connecting)
            {
                Thread.Sleep(3000);
                retryCount++;
                if (retryCount > 10)
                {
                    throw new TimeoutException("Timed out attempting to connect to the database.");
                }
            }

            return _connection;
        }
    }
}
