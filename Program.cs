using System;
using System.Threading;
using FileParserv2.Utility;

namespace FileParserv2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------- FILE PARSER - SAMET --------\n\r \n\r    !! LÜTFEN KAPATMAYIN!!");
            Parser parser = new Parser();
            while(true){
                parser.Parse();
            Thread.Sleep(550);
            }
        }
    }
}
