using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietApp
{
    public static class DatabaseManagement
    {
        private static string GetConnectionString()
        {
            ConnectionStringSettingsCollection settings =
                ConfigurationManager.ConnectionStrings;

            return settings[0].ConnectionString; //return App.config connection string

        }

        private static MySqlConnection returnConnection()
        {
            string connection_string = GetConnectionString();
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = connection_string;

            return con;
        }

        public static void updateData(string insert_query)
        {
            MySqlConnection con = returnConnection();
            con.Open();
            MySqlCommand cmd = new MySqlCommand(insert_query, con);
            cmd.ExecuteReader();
            con.Close();
        }

        public static List<List<string>> returnData(string select_query)
        {
            MySqlConnection con = returnConnection();
            con.Open();
            MySqlCommand cmd = new MySqlCommand(select_query, con);
            MySqlDataReader reader = cmd.ExecuteReader();
            
            List<List<string>> result_table = new List<List<string>>();
            int col = 0;

            while (reader.Read()) //iterate each row
            {
                List<string> result_row = new List<string>();

                while (col < reader.FieldCount) //iterate each column and store entire row in result_row
                {
                    result_row.Add(reader[col].ToString());
                    col++;
                }

                col = 0;
                result_table.Add(result_row);
            }

            con.Close();

            return result_table;
        }
    }
}
