using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParserv2.Data
{
    public static class MySqlDataService
    {
        private static string ConnectionString = "Data Source =195.155.134.251\\MSSQLSERVER2012; Initial Catalog=ICSamet; uid=sa; password=4dnNzT8!;";
        public static void InsertProximation(string thisDeviceName, string targetDeviceName, DateTime timestamp, int signalLevel)
        {
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            conn.Open();

            MySqlCommand insSqlCommand = new MySqlCommand("INSERT INTO Proximation (TagId,ProximityTagId,Timestamp,Strength) VALUES ('" + thisDeviceName + "','" + targetDeviceName + "','" + timestamp.ToString("yyyy-MM-dd HH:mm:ss") + "'," + Convert.ToString(signalLevel) + ")", conn);
            insSqlCommand.ExecuteNonQuery();
            conn.Close();
        }

        public static void InsertVoltage(string thisDeviceName, int battyInfo, DateTime f, int deviceCounter)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(ConnectionString);
                conn.Open();
                MySqlCommand insSqlCommand = new MySqlCommand("INSERT INTO Voltage VALUES ('" + thisDeviceName + "','" + battyInfo + "','" + f.ToString("yyyy-MM-dd HH:mm:ss") + "')", conn);
                insSqlCommand.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
