using System.Web.Http;
using TextParser.Parsers;

namespace TextParser.Controllers
{
    public class WebController : ApiController
    {
        [HttpPost]
        public string ToXml(string input)
        {
            var inputParser = new Parsers.TextParser(input);
            var xmlSerializer = new XmlParser(inputParser.Parse());
            return xmlSerializer.Parse();
        }
        [HttpPost]
        public string ToCsv(string input)
        {
            var inputParser = new Parsers.TextParser(input);
            var csvParser = new CsvParser(inputParser.Parse());
            return csvParser.Parse();
        }
    }
}
