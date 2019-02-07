using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data.Common;

namespace Inz_Prot.dbTools
{
    public static class dbAgent
    {
        private static string server = "localhost";
        private static string dataBaseName = "service";
        private static string user = "root";
        private static string password = "";
        private static bool isUsingDefaults = true;

        private static MySqlConnection mySqlConnection;


        public static bool IsUsingDefaultCredentials { get =>isUsingDefaults; }

        public static void UseDefaultCredentials()
        {
            server = "localhost";
            dataBaseName = "service";
            user = "root";
            password = "";
            initConnection();
            isUsingDefaults = true;
        }
         public static void UseCustomCredentials(string server,string databaseName,string user,string password)
        {
            dbAgent.server = server;
            dbAgent.dataBaseName = databaseName;
            dbAgent.user = user;
            dbAgent.password = password;
            initConnection();
            isUsingDefaults = false;
        }
        public static MySqlConnection GetConnection()
        {
            if (mySqlConnection == null)
            {
                initConnection();
                return mySqlConnection;     
            }
            else return mySqlConnection;

        }

        public static void initConnection()
        {
            MySqlConnectionStringBuilder connectionStringBuilder = new MySqlConnectionStringBuilder();

          
            connectionStringBuilder.Server = server;
            connectionStringBuilder.Database = dataBaseName;
            connectionStringBuilder.UserID = user;
            connectionStringBuilder.Password = password;
            connectionStringBuilder.SslMode = MySqlSslMode.None;
            connectionStringBuilder.AllowZeroDateTime = true;

            string connectionString = connectionStringBuilder.GetConnectionString(true);
            mySqlConnection = new MySqlConnection(connectionString);
        }

    }

   
}
