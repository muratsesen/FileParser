using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParserv2.Data
{
    public static class SqlDataService
    {
        private static string ConnectionString = "Data Source =\\MSSQLSERVER2012; Initial Catalog=; uid=sa; password=;";
        public static void InsertProximation(string thisDeviceName, string targetDeviceName, DateTime timestamp, int signalLevel) 
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();

            SqlCommand insSqlCommand = new SqlCommand("INSERT INTO Proximation (TagId,ProximityTagId,Timestamp,Strength) VALUES ('" + thisDeviceName + "','" + targetDeviceName + "','" + timestamp.ToString("yyyy-MM-dd HH:mm:ss") + "'," + Convert.ToString(signalLevel) + ")", conn);
            insSqlCommand.ExecuteNonQuery();
            conn.Close();
        }

        public static void InsertVoltage(string thisDeviceName, int battyInfo, DateTime f, int deviceCounter)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConnectionString);
                conn.Open();
                SqlCommand insSqlCommand = new SqlCommand("INSERT INTO Voltage VALUES ('" + thisDeviceName + "','" + battyInfo + "','" + f.ToString("yyyy-MM-dd HH:mm:ss") + "')", conn);
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
