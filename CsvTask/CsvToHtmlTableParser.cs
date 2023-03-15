using System;
using System.IO;

namespace CsvTask
{
    internal class CsvToHtmlTableParser
    {
        private string inputFileName;

        private string outputFileName;

        public CsvToHtmlTableParser(string inputFileName, string outputFileName)
        {
            this.inputFileName = inputFileName;
            this.outputFileName = outputFileName;
        }

        /// <summary>
        /// Method tries to parse input csv-formatted file as HTML table
        /// </summary>
        /// <returns> FALSE if parsing was successfull, TRUE if an error occured</returns>
        public bool TryParseAsHtmlTable()
        {
            bool isTableProcessing = false;
            bool isTableRowProcessing = false;
            bool isTableRowDetailProcessing = false;
            bool isTableRowSpecialDetailProcessing = false;
            bool isParsingError = false;

            string tableOpenTag = "<table>";
            string tableCloseTag = "</table>";
            string tableRowOpenTag = "<tr>";
            string tableRowCloseTag = "</tr>";
            string tableRowDetailOpenTag = "<td>";
            string tableRowDetailCloseTag = "</td>";
            string lineBreakTag = "<br/>";

            string temporaryFileName = outputFileName + ".tmp";
            using StreamWriter writer = new StreamWriter(temporaryFileName);

            writer.WriteLine("<!DOCTYPE html>");
            writer.WriteLine("<html class=\"no-js\">");
            writer.WriteLine("<head>");
            writer.WriteLine("<meta charset=\"UTF-8\">");
            writer.WriteLine("</head>");
            writer.WriteLine("<body>");

            using StreamReader reader = new StreamReader(inputFileName);

            while (true)
            {
                string outputString = "";

                int character1 = reader.Read();
                int character2 = reader.Peek();

                if (character1 == Environment.NewLine[0]) // LF or CRLF
                {
                    if (Environment.NewLine.Length == 2 && character2 == Environment.NewLine[1])
                    {
                        character2 = reader.Read();
                    }

                    if (isTableRowSpecialDetailProcessing)
                    {
                        outputString = lineBreakTag;
                    }
                    else // !isTableRowSpecialDetailProcessing
                    {
                        if (isTableRowDetailProcessing)
                        {
                            isTableRowDetailProcessing = false;
                            isTableRowProcessing = false;
                            outputString = tableRowDetailCloseTag + tableRowCloseTag + Environment.NewLine;
                        }
                        else // !isTableRowDetailProcessing && !isTableRowSpecialDetailProcessing
                        {
                            if (!isTableProcessing)
                            {
                                isTableProcessing = true;
                                outputString = tableOpenTag + Environment.NewLine;
                            }

                            if (!isTableRowProcessing)
                            {
                                outputString += tableRowOpenTag + tableRowCloseTag + Environment.NewLine;
                            }
                            else
                            {
                                isTableRowProcessing = false;
                                outputString += tableRowDetailOpenTag + tableRowDetailCloseTag + tableRowCloseTag + Environment.NewLine;
                            }
                        }
                    }
                }
                else if (character1 == '"') // "
                {
                    if (isTableRowSpecialDetailProcessing)
                    {
                        character1 = reader.Read();

                        if (character2 == '"') // ""
                        {
                            outputString = "" + '\"';
                        }
                        else if (character2 == ',') // ",
                        {
                            isTableRowSpecialDetailProcessing = false;
                            outputString = tableRowDetailCloseTag;
                        }
                        else if (character2 == -1) // "EOF
                        {
                            outputString = tableRowDetailCloseTag + tableRowCloseTag + Environment.NewLine + tableCloseTag + Environment.NewLine;
                        }
                        else // any other case
                        {
                            isParsingError = true;
                            isTableRowProcessing = false;
                            isTableRowDetailProcessing = false;
                            isTableRowSpecialDetailProcessing = false;
                            outputString = "";
                            break;
                        }
                    }
                    else // !isTableRowSpecialDetailProcessing
                    {
                        if (isTableRowDetailProcessing)
                        {
                            isParsingError = true;
                            isTableRowProcessing = false;
                            isTableRowDetailProcessing = false;
                            isTableRowSpecialDetailProcessing = false;
                            outputString = "";
                            break;
                        }

                        if (!isTableProcessing)
                        {
                            isTableProcessing = true;
                            outputString = tableOpenTag + Environment.NewLine;
                        }

                        if (!isTableRowProcessing)
                        {
                            isTableRowProcessing = true;
                            outputString += tableRowOpenTag;
                        }

                        isTableRowSpecialDetailProcessing = true;
                        outputString += tableRowDetailOpenTag;
                    }
                }
                else if (character1 == ',') // ,
                {
                    if (isTableRowSpecialDetailProcessing)
                    {
                        outputString = ",";
                    }
                    else // !isTableRowSpecialDetailProcessing
                    {
                        if (!isTableProcessing)
                        {
                            isTableProcessing = true;
                            outputString = tableOpenTag + Environment.NewLine;
                        }

                        if (!isTableRowProcessing)
                        {
                            isTableRowProcessing = true;
                            outputString += tableRowOpenTag;
                        }

                        if (isTableRowDetailProcessing)
                        {
                            outputString += tableRowDetailCloseTag + tableRowDetailOpenTag;
                        }
                        else // !isTableRowSpecialDetailProcessing && !isTableRowDetailProcessing
                        {
                            outputString += tableRowDetailOpenTag + tableRowDetailCloseTag + tableRowDetailOpenTag;
                        }

                        if (character2 == '"')
                        {
                            character1 = reader.Read();
                            isTableRowDetailProcessing = false;
                            isTableRowSpecialDetailProcessing = true;
                        }
                        else
                        {
                            isTableRowDetailProcessing = true;
                        }
                    }
                }
                else if (character1 == -1)
                {
                    if (isTableRowSpecialDetailProcessing)
                    {
                        isParsingError = true;
                        isTableRowProcessing = false;
                        isTableRowDetailProcessing = false;
                        isTableRowSpecialDetailProcessing = false;
                        outputString = "";
                        break;
                    }
                    else // !isTableRowSpecialDetailProcessing
                    {
                        if (isTableRowDetailProcessing)
                        {
                            isTableProcessing = false;
                            isTableRowProcessing = false;
                            isTableRowDetailProcessing = false;
                            outputString += tableRowDetailCloseTag + tableRowCloseTag + Environment.NewLine + tableCloseTag + Environment.NewLine;
                        }
                        else // !isTableRowSpecialDetailProcessing && !isTableRowDetailProcessing
                        {
                            if (isTableRowProcessing)
                            {
                                isTableRowProcessing = false;
                                outputString += tableRowCloseTag + Environment.NewLine;
                            }

                            if (isTableProcessing)
                            {
                                isTableProcessing = false;
                                outputString += tableCloseTag + Environment.NewLine;
                            }
                        }
                    }
                }
                else // other symbol
                {
                    if (!isTableProcessing)
                    {
                        isTableProcessing = true;
                        outputString = tableOpenTag + Environment.NewLine;
                    }

                    if (!isTableRowProcessing)
                    {
                        isTableRowProcessing = true;
                        outputString += tableRowOpenTag;
                    }

                    if (!isTableRowDetailProcessing && !isTableRowSpecialDetailProcessing)
                    {
                        isTableRowDetailProcessing = true;
                        outputString += tableRowDetailOpenTag;
                    }

                    if (character1 == '<')
                    {
                        outputString += "&lt";
                    }
                    else if (character1 == '>')
                    {
                        outputString += "&gt";
                    }
                    else if (character1 == '&')
                    {
                        outputString += "&amp";
                    }
                    else
                    {
                        outputString += (char)character1;
                    }
                }

                writer.Write(outputString);

                if (character1 == -1)
                {
                    break;
                }
            }

            writer.WriteLine("</body>");
            writer.WriteLine("</html>");

            writer.Dispose();

            if (!isParsingError)
            {
                File.Copy(temporaryFileName, outputFileName, true);
            }

            File.Delete(temporaryFileName);

            return isParsingError;
        }
    }
}
