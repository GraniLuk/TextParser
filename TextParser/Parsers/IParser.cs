using TextParser.Models;

namespace TextParser.Parsers
{
    public interface IParser
    {
        string Parse(Text text);
    }
}