using System.Web.Http;
using TextParser.Models;
using TextParser.Parsers;

namespace TextParser.Controllers
{
    public class WebController : ApiController
    {
        [HttpPost]
        public string ToXml(string input)
        {
            var xmlSerializer = new XmlParser(new Text(input));
            return xmlSerializer.Parse();
        }
        [HttpPost]
        public string ToCsv(string input)
        {
            var csvParser = new CsvParser(new Text(input));
            return csvParser.Parse();
        }
    }
}
