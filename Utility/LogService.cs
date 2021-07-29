using System;
using System.IO;
using System.Threading;

namespace FileParserv2.Utility
{
    public static class LogService
    {
       // public static IConfiguration Configuration = new Configuration();
        public static void Log(string message)
        {
            string folderPath = Environment.CurrentDirectory+@"/Log";
            string path = Environment.CurrentDirectory+@"/Log/LogFile.txt";
            // if (!Directory.Exists(folderPath))
            // {
            //     Directory.CreateDirectory(folderPath);
                
            // }
            // using (FileStream fs = new FileStream(path, FileMode.Create))
            // {
            //     fs.Close();
            // }
            using (StreamWriter sw = File.AppendText(path))
            {
               sw.WriteLine(message);
            }
            
        }
    }
}