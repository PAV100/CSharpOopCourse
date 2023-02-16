using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace CsvTask
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Program demonstrates CsvParser class functionality");
            Console.WriteLine();            

            string inputFilePath = "..\\..\\..\\input2.csv";
            string outputFilePath = "..\\..\\..\\output2.html";

            CsvParser csvParser = new(inputFilePath, outputFilePath);

            string htmlTableRowDetails = csvParser.TryParseAsHtmlTable();
            //Console.WriteLine("{0}", htmlTableRowDetails);            
        }
    }
}