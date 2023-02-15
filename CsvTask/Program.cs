using System;
using System.IO;
using System.Text.RegularExpressions;

namespace CsvTask
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("Program demonstrates...");

            string csvFilePath = "..\\..\\..\\input2.csv";
            string htmlFilePath = "..\\..\\..\\output.html";

            CsvToHtmlConvert(csvFilePath, htmlFilePath);
        }

        static void CsvToHtmlConvert(string csvFilePath, string htmlFilePath)
        {
            Regex regex = new Regex(@"0123");
            
            //regex

            using (StreamReader reader = new StreamReader(csvFilePath))
            {
                using StreamWriter writer = new StreamWriter(htmlFilePath);

                string currentLine;

                while ((currentLine = reader.ReadLine()) != null)
                {


                    Console.WriteLine(currentLine);

                    writer.WriteLine(currentLine.ToUpper());
                }
            }
        }
    }
}