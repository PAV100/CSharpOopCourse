using System;
using System.Text;
using System.IO;

namespace CsvTask
{
    internal class CsvParser
    {
        private string inputFileName;

        private string outputFileName;

        private bool isTableProcessing;

        private StringBuilder inputBuffer;

        private StringBuilder outputBuffer;

        public CsvParser(string inputFileName, string outputFileName)
        {
            this.inputFileName = inputFileName;
            this.outputFileName = outputFileName;
            inputBuffer = new StringBuilder();
            outputBuffer = new StringBuilder();
        }

        public string TryParseAsHtmlTable()
        {
            Console.WriteLine("Opening input file...");

            using (StreamReader reader = new StreamReader(inputFileName))
            {
                outputBuffer.Append("<table>");

                string inputFileCurrentLine;

                string htmlRow = null;

                while ((inputFileCurrentLine = reader.ReadLine()) != null)
                {
                    isTableProcessing = true;

                    inputBuffer.Append(inputFileCurrentLine);

                    htmlRow = TryParseAsHtmlTableRow(inputBuffer.ToString());

                    if (htmlRow is null)
                    {
                        inputBuffer.Append(Environment.NewLine);
                        continue;
                    }

                    outputBuffer.Append(htmlRow);

                    inputBuffer.Clear();
                }

                if (!isTableProcessing)
                {
                    Console.WriteLine("Input file is empty, nothing has been read");
                    outputBuffer.Clear();
                    return "";
                }

                if (isTableProcessing && htmlRow is null)
                {
                    Console.WriteLine("Input file can not be parsed as HTML table");
                    outputBuffer.Clear();
                    return "";
                }

                Console.WriteLine("Parcing completed successfuly");

                outputBuffer.Append("</table>");
                                
                using StreamWriter writer = new StreamWriter(outputFileName);
                writer.WriteLine(outputBuffer);

                Console.WriteLine("Writing to output file...");
            }

            return outputBuffer.ToString();
        }

        private string TryParseAsHtmlTableRow(string s)
        {
            if (HasEvenSymbolsCount(s, '"'))
            {
                return null;
            }

            if (s.Length == 0)
            {
                return "<tr><td></td></tr>";
            }

            string[] commaSeparatedStrings = s.ToString().Split(",");

            string htmlRowDetail = null;

            StringBuilder commaSeparatedString = new();

            StringBuilder htmlRow = new();

            for (int i = 0; i < commaSeparatedStrings.Length; i++)
            {
                commaSeparatedString.Append(commaSeparatedStrings[i]);

                htmlRowDetail = TryParseAsHtmlTableRowDetail(commaSeparatedString.ToString());

                if (htmlRowDetail is null)
                {
                    commaSeparatedString.Append(",");
                    continue;
                }

                htmlRow.Append(htmlRowDetail);

                commaSeparatedString.Clear();
            }

            if (htmlRowDetail is null)
            {
                return null;
            }

            return "<tr>" + htmlRow.ToString() + "</tr>";
        }

        private string TryParseAsHtmlTableRowDetail(string s)
        {
            if (HasEvenSymbolsCount(s, '"'))
            {
                return null;
            }

            if (s.Length == 0)
            {
                return "<td></td>";
            }

            if (s.Length == 1)
            {
                return "<td>" + s + "</td>";
            }

            string htmlTableRowDetail = s;

            if (s[0].Equals('"') && s[s.Length - 1].Equals('"'))
            {
                htmlTableRowDetail = s.Substring(1, s.Length - 2);

                // check for """, """"", ... etc 
                for (string duplicatedQuotes = "\"\"\""; duplicatedQuotes.Length < htmlTableRowDetail.Length; duplicatedQuotes = duplicatedQuotes + "\"\"")
                {
                    if (htmlTableRowDetail.Contains(duplicatedQuotes))
                    {
                        return null;
                    }
                }

                htmlTableRowDetail = htmlTableRowDetail.Replace(Environment.NewLine, "<br/>");
                htmlTableRowDetail = htmlTableRowDetail.Replace("\"\"", "\"");
                return "<td>" + htmlTableRowDetail + "</td>";
            }

            if (!s[0].Equals('"') && !s[s.Length - 1].Equals('"'))
            {
                if (s.Contains('"'))
                {
                    return null;
                }

                return "<td>" + s + "</td>";
            }

            return null;
        }

        private bool HasEvenSymbolsCount(string s, char ch)
        {
            return (Array.FindAll(s.ToString().ToCharArray(), x => x == ch).Length % 2) != 0;
        }
    }
}