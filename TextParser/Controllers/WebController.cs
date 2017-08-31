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
            return new Text() { Input = input }.ParseTo(new XmlParser());
        }
        [HttpPost]
        public string ToCsv(string input)
        {
            return new Text() { Input = input }.ParseTo(new CsvParser());
        }
    }
}
