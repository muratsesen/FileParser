using FileParserv2.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParserv2
{
    public class Parser
    {
        //private string PathToFiles = "C:\\incontact_ftp\\";
        private string PathToFiles = Environment.CurrentDirectory;
        //private string PathToProcessed = "C:\\incontact_ftp\\";
        private string PathToProcessed = Environment.CurrentDirectory + "/processed/";
        
        public void Parse()
        {
            DirectoryInfo directory = new DirectoryInfo(PathToFiles);//Assuming Test is your Folder
            FileInfo[] Files = directory.GetFiles("*.csv");
            foreach (FileInfo file in Files)
            {

                string values = File.ReadAllText(file.FullName);
                string[] lines = values.Split(new string[] { "\r\n" }, StringSplitOptions.None);


                string thisDeviceName = Convert.ToString(file.Name.Replace(".csv", "").Split('_')[0]);
                int battyInfo = Convert.ToInt32(file.Name.Replace(".csv", "").Split('_')[1]);
                int deviceCounter = Convert.ToInt32(file.Name.Replace(".csv", "").Split('_')[2]);
                //Calculate time
                FileInfo fileInfo = new FileInfo(file.FullName);
                DateTime fileDateLastWriteTime = fileInfo.LastWriteTime;
                DateTime fileDateCreationTime = fileInfo.CreationTime;
                //Save battry
                SqlDataService.InsertVoltage(thisDeviceName, battyInfo, fileDateLastWriteTime, deviceCounter);
                MySqlDataService.InsertVoltage(thisDeviceName, battyInfo, fileDateLastWriteTime, deviceCounter);

                
                foreach (string line in lines)
                {
                    string[] lineValues = line.Split(',');
                    if (string.IsNullOrEmpty(lineValues[0]))
                    {
                        break;
                    }
                    //Timestamp, Cihaz, Seviye
                    try
                    {
                        var lineV = lineValues[0];
                        int lineVInt = Convert.ToInt32(lineValues[0]);
                        var ms = deviceCounter - lineVInt;
                        DateTime timestamp = fileDateCreationTime.AddSeconds(-1 * (ms));
                        DateTime timestamp2 = fileDateLastWriteTime.AddSeconds(-1 * (ms));
                        string targetDeviceName = Convert.ToString(lineValues[1]);
                        int signalLevel = Convert.ToInt32(lineValues[2]);

                        //A-B
                        SqlDataService.InsertProximation(thisDeviceName, targetDeviceName, timestamp, signalLevel);
                        MySqlDataService.InsertProximation(thisDeviceName, targetDeviceName, timestamp, signalLevel);

                    }
                    catch (Exception ex)
                    {
                        //LogService.Log(ex.Message);

                    }
                }

                //Rename and move
                DirectoryInfo processedFileDir = new DirectoryInfo(PathToProcessed);//Assuming Test is your Folder
                FileInfo destinationFile = new FileInfo(processedFileDir + "\\" + file.Name.Replace("csv", "processed"));
                System.IO.File.Move(file.FullName, destinationFile.FullName);
      

            }
        }
    }

}
