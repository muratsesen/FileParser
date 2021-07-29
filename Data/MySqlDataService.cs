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
        private static string ConnectionString = "Server=195.155.134.251;Port=3306; Database=samet; Uid=samet; Pwd=Samet2021!;";
        public static void InsertProximation(string thisDeviceName, string targetDeviceName, DateTime timestamp, int signalLevel)
        {
            using (MySqlConnection conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();

                MySqlCommand insSqlCommand = new MySqlCommand("INSERT INTO Proximation (tag_id,proximation_tag_id,timestamp,strength) VALUES ('" + thisDeviceName + "','" + targetDeviceName + "','" + timestamp.ToString("yyyy-MM-dd HH:mm:ss") + "'," + Convert.ToString(signalLevel) + ")", conn);
                insSqlCommand.ExecuteNonQuery();
                conn.Close();
            }
        }

        public static void InsertVoltage(string thisDeviceName, int battyInfo, int createdBy,DateTime f)
        {
            //createdBy = 1: from file name
            //createdBy = 2: from inside file
            try
            {
                MySqlConnection conn = new MySqlConnection(ConnectionString);
                conn.Open();
                MySqlCommand insSqlCommand = new MySqlCommand("INSERT INTO Voltage (tag_id,voltage,created_by,timestamp) VALUES ('" + thisDeviceName + "','" + battyInfo + "','"+ createdBy + "','" + f.ToString("yyyy-MM-dd HH:mm:ss") + "')", conn);
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
