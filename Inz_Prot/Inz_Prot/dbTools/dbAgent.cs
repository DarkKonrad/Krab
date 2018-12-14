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
        private static string Server = "localhost";
        private static string DataBaseName = "service";
        private static string User = "root";
        private static string Password = "";

        private static MySqlConnection mySqlConnection;

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

          
            connectionStringBuilder.Server = Server;
            connectionStringBuilder.Database = DataBaseName;
            connectionStringBuilder.UserID = User;
            connectionStringBuilder.Password = Password;
            connectionStringBuilder.SslMode = MySqlSslMode.None;

            // string connectionString = connectionStringBuilder.ToString() ;
            string connectionString = connectionStringBuilder.GetConnectionString(true);
            mySqlConnection = new MySqlConnection(connectionString);
        }

    }

   
}
