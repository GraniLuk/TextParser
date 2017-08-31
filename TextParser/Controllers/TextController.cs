using System.Web.Mvc;
using TextParser.Attributes;
using TextParser.Models;
using TextParser.Parsers;

namespace TextParser.Controllers
{
    public class TextController : Controller
    {
        public ActionResult Parser()
        {
            var text = new Text();
            return View(text);
        }
        // GET: Text
        [HttpPost]
        [MultipleButton(Name = "action", Argument = "ToXml")]
        public ActionResult ToXml(Text text)
        {
            return Content(text.ParseTo(new XmlParser()), "text/xml");
        }

        [HttpPost]
        [MultipleButton(Name = "action", Argument = "ToCsv")]
        public ActionResult ToCsv(Text text)
        {
            return Content(text.ParseTo(new CsvParser()), "text/richtext");
        }
    }
}