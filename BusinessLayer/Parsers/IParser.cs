using System.Collections.Generic;

namespace BusinessLayer.Parsers
{
    public interface IParser<T>
    {
        IEnumerable<T> ParseFile(string fileName);
    }
}
