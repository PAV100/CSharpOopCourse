using System;
using System.IO;

namespace CsvTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program demonstrates ConvertCsvFileToHtmlFile() method");
            Console.WriteLine();

            if (args.Length != 2)
            {
                Console.WriteLine("Usage: CsvTask CSV-file HTML-file");
                Console.WriteLine("  CSV-file - input csv-formatted file to convert");
                Console.WriteLine("  HTML-file - output html-formatted file containing converting result");

                return;
            }

            string inputFileName = args[0];
            string outputFileName = args[1];

            Console.WriteLine($"Trying to convert file {inputFileName} to HTML table...");

            if (ConvertCsvFileToHtmlFile(inputFileName, outputFileName))
            {
                Console.WriteLine("Converting Error!");
            }
            else
            {
                Console.WriteLine($"Converting successful. File {outputFileName} written!");
            }
        }

        /// <summary>
        /// Method tries to covert input csv-formatted file to HTML table and to write it to HTML-formatted file
        /// </summary>
        /// <returns> FALSE if conversion was successful, TRUE if an error occured</returns>
        public static bool ConvertCsvFileToHtmlFile(string csvFileName, string htmlFileName)
        {
            const string TableOpenTag = "<table>";
            const string TableCloseTag = "</table>";
            const string TableRowOpenTag = "<tr>";
            const string TableRowCloseTag = "</tr>";
            const string TableRowDetailOpenTag = "<td>";
            const string TableRowDetailCloseTag = "</td>";
            const string LineBreakTag = "<br/>";

            bool isTableProcessing = false;
            bool isTableRowProcessing = false;
            bool isTableRowDetailProcessing = false;
            bool isTableRowSpecialDetailProcessing = false;
            bool isConvertingError = false;

            try
            {
                using StreamReader reader = new(csvFileName);

                string temporaryFileName = htmlFileName + ".tmp";
                using (StreamWriter writer = new(temporaryFileName))
                {

                    writer.WriteLine("<!DOCTYPE html>");
                    writer.WriteLine("<html class=\"no-js\">");
                    writer.WriteLine("<head>");
                    writer.WriteLine("\t<meta charset=\"UTF-8\">");
                    writer.WriteLine("\t<title>HTML Title</title>");
                    writer.WriteLine("</head>");
                    writer.WriteLine("<body>");

                    while (true)
                    {
                        int currentCharacter = reader.Read();
                        int nextCharacter = reader.Peek();

                        if (currentCharacter == Environment.NewLine[0]) // LF or CRLF
                        {
                            if (Environment.NewLine.Length == 2 && nextCharacter == Environment.NewLine[1])
                            {
                                nextCharacter = reader.Read();
                            }

                            if (isTableRowSpecialDetailProcessing)
                            {
                                writer.Write(LineBreakTag);
                            }
                            else // !isTableRowSpecialDetailProcessing
                            {
                                if (isTableRowDetailProcessing)
                                {
                                    isTableRowDetailProcessing = false;
                                    isTableRowProcessing = false;
                                    writer.Write(TableRowDetailCloseTag);
                                    writer.Write(TableRowCloseTag);
                                    writer.Write(Environment.NewLine);
                                }
                                else // !isTableRowDetailProcessing && !isTableRowSpecialDetailProcessing
                                {
                                    if (!isTableProcessing)
                                    {
                                        isTableProcessing = true;
                                        writer.Write(TableOpenTag);
                                        writer.Write(Environment.NewLine);
                                    }

                                    if (!isTableRowProcessing)
                                    {
                                        writer.Write(TableRowOpenTag);
                                        writer.Write(TableRowCloseTag);
                                        writer.Write(Environment.NewLine);
                                    }
                                    else
                                    {
                                        isTableRowProcessing = false;
                                        writer.Write(TableRowDetailOpenTag);
                                        writer.Write(TableRowDetailCloseTag);
                                        writer.Write(TableRowCloseTag);
                                        writer.Write(Environment.NewLine);
                                    }
                                }
                            }
                        }
                        else if (currentCharacter == '"') // "
                        {
                            if (isTableRowSpecialDetailProcessing)
                            {
                                currentCharacter = reader.Read();

                                if (nextCharacter == '"') // ""
                                {
                                    writer.Write("\"");
                                }
                                else if (nextCharacter == ',') // ",
                                {
                                    isTableRowSpecialDetailProcessing = false;
                                    writer.Write(TableRowDetailCloseTag);
                                }
                                else if (nextCharacter == -1) // "EOF
                                {
                                    writer.Write(TableRowDetailCloseTag);
                                    writer.Write(TableRowCloseTag);
                                    writer.Write(Environment.NewLine);
                                    writer.Write(TableCloseTag);
                                    writer.Write(Environment.NewLine);
                                }
                                else // any other case
                                {
                                    isConvertingError = true;
                                    break;
                                }
                            }
                            else // !isTableRowSpecialDetailProcessing
                            {
                                if (isTableRowDetailProcessing)
                                {
                                    isConvertingError = true;
                                    break;
                                }

                                if (!isTableProcessing)
                                {
                                    isTableProcessing = true;
                                    writer.Write(TableOpenTag);
                                    writer.Write(Environment.NewLine);
                                }

                                if (!isTableRowProcessing)
                                {
                                    isTableRowProcessing = true;
                                    writer.Write(TableRowOpenTag);
                                }

                                isTableRowSpecialDetailProcessing = true;
                                writer.Write(TableRowDetailOpenTag);
                            }
                        }
                        else if (currentCharacter == ',') // ,
                        {
                            if (isTableRowSpecialDetailProcessing)
                            {
                                writer.Write(",");
                            }
                            else // !isTableRowSpecialDetailProcessing
                            {
                                if (!isTableProcessing)
                                {
                                    isTableProcessing = true;
                                    writer.Write(TableOpenTag);
                                    writer.Write(Environment.NewLine);
                                }

                                if (!isTableRowProcessing)
                                {
                                    isTableRowProcessing = true;
                                    writer.Write(TableRowOpenTag);
                                }

                                if (isTableRowDetailProcessing)
                                {
                                    writer.Write(TableRowDetailCloseTag);
                                    writer.Write(TableRowDetailOpenTag);
                                }
                                else // !isTableRowSpecialDetailProcessing && !isTableRowDetailProcessing
                                {
                                    writer.Write(TableRowDetailOpenTag);
                                    writer.Write(TableRowDetailCloseTag);
                                    writer.Write(TableRowDetailOpenTag);
                                }

                                if (nextCharacter == '"')
                                {
                                    currentCharacter = reader.Read();
                                    isTableRowDetailProcessing = false;
                                    isTableRowSpecialDetailProcessing = true;
                                }
                                else
                                {
                                    isTableRowDetailProcessing = true;
                                }
                            }
                        }
                        else if (currentCharacter == -1) // EOF
                        {
                            if (isTableRowSpecialDetailProcessing)
                            {
                                isConvertingError = true;
                                break;
                            }
                            else // !isTableRowSpecialDetailProcessing
                            {
                                if (isTableRowDetailProcessing)
                                {
                                    isTableProcessing = false;
                                    isTableRowProcessing = false;
                                    isTableRowDetailProcessing = false;
                                    writer.Write(TableRowDetailCloseTag);
                                    writer.Write(TableRowCloseTag);
                                    writer.Write(Environment.NewLine);
                                    writer.Write(TableCloseTag);
                                    writer.Write(Environment.NewLine);
                                }
                                else // !isTableRowSpecialDetailProcessing && !isTableRowDetailProcessing
                                {
                                    if (isTableRowProcessing)
                                    {
                                        isTableRowProcessing = false;
                                        writer.Write(TableRowCloseTag);
                                        writer.Write(Environment.NewLine);
                                    }

                                    if (isTableProcessing)
                                    {
                                        isTableProcessing = false;
                                        writer.Write(TableCloseTag);
                                        writer.Write(Environment.NewLine);
                                    }
                                }
                            }
                        }
                        else // other symbol
                        {
                            if (!isTableProcessing)
                            {
                                isTableProcessing = true;
                                writer.Write(TableOpenTag);
                                writer.Write(Environment.NewLine);
                            }

                            if (!isTableRowProcessing)
                            {
                                isTableRowProcessing = true;
                                writer.Write(TableRowOpenTag);
                            }

                            if (!isTableRowDetailProcessing && !isTableRowSpecialDetailProcessing)
                            {
                                isTableRowDetailProcessing = true;
                                writer.Write(TableRowDetailOpenTag);
                            }

                            if (currentCharacter == '<')
                            {
                                writer.Write("&lt;");
                            }
                            else if (currentCharacter == '>')
                            {
                                writer.Write("&gt;");
                            }
                            else if (currentCharacter == '&')
                            {
                                writer.Write("&amp;");
                            }
                            else
                            {
                                writer.Write((char)currentCharacter);
                            }
                        }

                        if (currentCharacter == -1)
                        {
                            break;
                        }
                    }

                    writer.WriteLine("</body>");
                    writer.WriteLine("</html>");
                }

                if (!isConvertingError)
                {
                    try
                    {
                        File.Copy(temporaryFileName, htmlFileName, true);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Temporary {temporaryFileName} to output {htmlFileName} file coping error");

                        return true;
                    }
                }

                try
                {
                    File.Delete(temporaryFileName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Temporary file {temporaryFileName} deleting error");

                    return true;
                }

                return isConvertingError;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Input {csvFileName} or output {htmlFileName} file error");

                return true;
            }
        }
    }
}
