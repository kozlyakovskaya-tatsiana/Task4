using System.Collections.Generic;
using System.IO;

namespace BusinessLayer.Parsers.Models
{
    public class CsvParser : IParser<CsvLine>
    {
        public IEnumerable<CsvLine> ParseFile(string fileName)
        {
            if (!File.Exists(fileName)) throw new FileNotFoundException($"{fileName} is not found");

            var managerName = new FileInfo(fileName).Name.Split('_')[0];

            var listCsvLines = new List<CsvLine>();

            using(StreamReader reader = new StreamReader(fileName))
            {
                string line;

                while((line=reader.ReadLine())!=null)
                {
                    string[] dataInLine = line.Split(';');

                    listCsvLines.Add(new CsvLine(managerName, dataInLine[0], dataInLine[1], dataInLine[2], dataInLine[3]));
                }
            }

            return listCsvLines;
        }
    }
}
