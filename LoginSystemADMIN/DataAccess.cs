using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;

namespace LoginSystemADMIN
{
    class DataAccess
    {
        static string connectionString = @"Data Source=.\login.db;Version=3;New=false;";

        static SQLiteConnection _connection = null;
        public static SQLiteConnection connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new SQLiteConnection(connectionString);
                    _connection.Open();

                    return _connection;
                }
                else if (_connection.State != System.Data.ConnectionState.Open)
                {
                    _connection.Open();

                    return _connection;
                }
                else
                {
                    return _connection;
                }
            }
        }

        public static DataSet GetDataSet(string sql)
        {
            SQLiteCommand cmd = new SQLiteCommand(sql, connection);
            SQLiteDataAdapter adp = new SQLiteDataAdapter(cmd);

            DataSet ds = new DataSet();           
            adp.Fill(ds);
            connection.Close();
             
            return ds;
        }

        public static DataTable GetDataTable(string sql)
        {
            Console.WriteLine(sql);
            DataSet ds = GetDataSet(sql);

            if (ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }

        public static int ExecuteSQL(string sql)
        {
            SQLiteCommand cmd = new SQLiteCommand(sql, connection);
            return cmd.ExecuteNonQuery();
        }
    }
}
