using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T2009M1HelloUWP.Utils
{
    public class ConnectionHelper
    {
        private static string DatabaseServer = "localhost";
        private static string DatabaseName = "students";
        private static string DatabaseUsername = "root";
        private static string DatabasePassword = "";
        private static string ConnectionString =
            $"Server={DatabaseServer};" +
            $"Database={DatabaseName};" +
            $"Uid={DatabaseUsername};" +
            $"Pwd={DatabasePassword};";

        private static MySqlConnection connection;

        public static MySqlConnection GetConnection()
        {
            if (connection == null
                || connection.State == System.Data.ConnectionState.Closed)
            {
                connection = new MySqlConnection(ConnectionString);
            }
            return connection;
        }
    }
}
