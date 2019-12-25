using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BusinessLayer.Parsers.Models
{
    public class CsvParser : IParser<CsvLine>
    {
        public IEnumerable<CsvLine> ParseFile(string fileName)
        {
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
