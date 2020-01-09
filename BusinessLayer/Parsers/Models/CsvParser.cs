using System;
using System.Collections.Generic;
using System.IO;

namespace BusinessLayer.Parsers.Models
{
    public class CsvParser : IParser<CsvLine>
    {
        public IEnumerable<CsvLine> ParseFile(string fileName)
        {
            var listCsvLines = new List<CsvLine>();

            var managerName = new FileInfo(fileName).Name.Split('_')[0];

            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    try
                    {
                        string[] dataInLine = line.Split(';');

                        listCsvLines.Add(new CsvLine(managerName, dataInLine[0], dataInLine[1], dataInLine[2], dataInLine[3]));
                    }
                    catch (Exception ex)
                    {
                        Log.Write($"\"{line}\" was not added because of " + ex.Message);
                    }
                }
            }

            return listCsvLines;
        }

    }
}

