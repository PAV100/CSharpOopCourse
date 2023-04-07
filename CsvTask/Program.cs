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
                Console.WriteLine($"Converting successful. File {outputFileName} written!");
            }
            else
            {
                Console.WriteLine("Converting Error!");
            }
        }

        /// <summary>
        /// Method tries to covert input csv-formatted file to HTML table and to write it to HTML-formatted file
        /// </summary>
        /// <returns> TRUE if conversion was successful, FALSE if an error occurred</returns>
        public static bool ConvertCsvFileToHtmlFile(string csvFileName, string htmlFileName)
        {
            try
            {
                bool isTableProcessing = false;
                bool isTableRowProcessing = false;
                bool isTableRowDetailProcessing = false;
                bool isTableRowSpecialDetailProcessing = false;
                bool isConvertingError = false;

                using StreamReader reader = new(csvFileName);

                string temporaryFileName = htmlFileName + ".tmp";
                using (StreamWriter writer = new(temporaryFileName))
                {
                    const string tableOpenTag = "<table>";
                    const string tableCloseTag = "</table>";
                    const string tableRowOpenTag = "<tr>";
                    const string tableRowCloseTag = "</tr>";
                    const string tableRowDetailOpenTag = "<td>";
                    const string tableRowDetailCloseTag = "</td>";
                    const string lineBreakTag = "<br/>";

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
                                writer.Write(lineBreakTag);
                            }
                            else // !isTableRowSpecialDetailProcessing
                            {
                                if (isTableRowDetailProcessing)
                                {
                                    isTableRowDetailProcessing = false;
                                    isTableRowProcessing = false;
                                    writer.Write(tableRowDetailCloseTag);
                                    writer.Write(tableRowCloseTag);
                                    writer.Write(Environment.NewLine);
                                }
                                else // !isTableRowDetailProcessing && !isTableRowSpecialDetailProcessing
                                {
                                    if (!isTableProcessing)
                                    {
                                        isTableProcessing = true;
                                        writer.Write(tableOpenTag);
                                        writer.Write(Environment.NewLine);
                                    }

                                    if (!isTableRowProcessing)
                                    {
                                        writer.Write(tableRowOpenTag);
                                        writer.Write(tableRowCloseTag);
                                        writer.Write(Environment.NewLine);
                                    }
                                    else
                                    {
                                        isTableRowProcessing = false;
                                        writer.Write(tableRowDetailOpenTag);
                                        writer.Write(tableRowDetailCloseTag);
                                        writer.Write(tableRowCloseTag);
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
                                    writer.Write(tableRowDetailCloseTag);
                                }
                                else if (nextCharacter == -1) // "EOF
                                {
                                    writer.Write(tableRowDetailCloseTag);
                                    writer.Write(tableRowCloseTag);
                                    writer.Write(Environment.NewLine);
                                    writer.Write(tableCloseTag);
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
                                    writer.Write(tableOpenTag);
                                    writer.Write(Environment.NewLine);
                                }

                                if (!isTableRowProcessing)
                                {
                                    isTableRowProcessing = true;
                                    writer.Write(tableRowOpenTag);
                                }

                                isTableRowSpecialDetailProcessing = true;
                                writer.Write(tableRowDetailOpenTag);
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
                                    writer.Write(tableOpenTag);
                                    writer.Write(Environment.NewLine);
                                }

                                if (!isTableRowProcessing)
                                {
                                    isTableRowProcessing = true;
                                    writer.Write(tableRowOpenTag);
                                }

                                if (isTableRowDetailProcessing)
                                {
                                    writer.Write(tableRowDetailCloseTag);
                                    writer.Write(tableRowDetailOpenTag);
                                }
                                else // !isTableRowSpecialDetailProcessing && !isTableRowDetailProcessing
                                {
                                    writer.Write(tableRowDetailOpenTag);
                                    writer.Write(tableRowDetailCloseTag);
                                    writer.Write(tableRowDetailOpenTag);
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

                            // !isTableRowSpecialDetailProcessing
                            if (isTableRowDetailProcessing)
                            {
                                isTableProcessing = false;
                                isTableRowProcessing = false;
                                isTableRowDetailProcessing = false;
                                writer.Write(tableRowDetailCloseTag);
                                writer.Write(tableRowCloseTag);
                                writer.Write(Environment.NewLine);
                                writer.Write(tableCloseTag);
                                writer.Write(Environment.NewLine);
                            }
                            else // !isTableRowSpecialDetailProcessing && !isTableRowDetailProcessing
                            {
                                if (isTableRowProcessing)
                                {
                                    isTableRowProcessing = false;
                                    writer.Write(tableRowCloseTag);
                                    writer.Write(Environment.NewLine);
                                }

                                if (isTableProcessing)
                                {
                                    isTableProcessing = false;
                                    writer.Write(tableCloseTag);
                                    writer.Write(Environment.NewLine);
                                }
                            }
                        }
                        else // other symbol
                        {
                            if (!isTableProcessing)
                            {
                                isTableProcessing = true;
                                writer.Write(tableOpenTag);
                                writer.Write(Environment.NewLine);
                            }

                            if (!isTableRowProcessing)
                            {
                                isTableRowProcessing = true;
                                writer.Write(tableRowOpenTag);
                            }

                            if (!isTableRowDetailProcessing && !isTableRowSpecialDetailProcessing)
                            {
                                isTableRowDetailProcessing = true;
                                writer.Write(tableRowDetailOpenTag);
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
                    catch (Exception e)
                    {
                        Console.WriteLine($"Temporary {temporaryFileName} to output {htmlFileName} file coping error");
                        Console.WriteLine("Error details:");
                        Console.WriteLine(e.Message);

                        return false;
                    }
                }

                try
                {
                    File.Delete(temporaryFileName);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Temporary file {temporaryFileName} deleting error");
                    Console.WriteLine("Error details:");
                    Console.WriteLine(e.Message);

                    return false;
                }

                return !isConvertingError;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Input {csvFileName} or output {htmlFileName} file error");
                Console.WriteLine("Error details:");
                Console.WriteLine(e.Message);

                return false;
            }
        }
    }
}
