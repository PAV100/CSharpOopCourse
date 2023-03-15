using System;

namespace CsvTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program demonstrates CsvToHtmlTableParser class functionality");
            Console.WriteLine();

            if (args.Length != 2)
            {
                Console.WriteLine("Usage: CsvTask CSV-file HTML-file");
                Console.WriteLine("  CSV-file - input csv-formatted file to parse");
                Console.WriteLine("  HTML-file - output html-formatted file containing the result of parsing");

                return;
            }

            string inputFileName = args[0];
            string outputFileName = args[1];

            Console.WriteLine($"Trying to parse file {inputFileName} as HTML table...");

            CsvToHtmlTableParser csvParser = new(inputFileName, outputFileName);

            if (csvParser.TryParseAsHtmlTable())
            {
                Console.WriteLine("Parsing Error!");
            }
            else
            {
                Console.WriteLine($"Parsing successful. File {outputFileName} written!");
            }
        }
    }
}
