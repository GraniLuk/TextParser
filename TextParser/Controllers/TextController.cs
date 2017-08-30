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
            var inputForm = new InputForm();
            return View(inputForm);
        }
        // GET: Text
        [HttpPost]
        [MultipleButton(Name = "action", Argument = "ToXml")]
        public ActionResult ToXml(InputForm inputForm)
        {
            var xmlSerializer = new XmlParser(new Text(inputForm.Input));
            return Content(xmlSerializer.Parse(), "text/xml");
        }

        [HttpPost]
        [MultipleButton(Name = "action", Argument = "ToCsv")]
        public ActionResult ToCsv(InputForm inputForm)
        {
            var csvSerializer = new CsvParser(new Text(inputForm.Input));
            return Content(csvSerializer.Parse(), "text/richtext");
        }
    }
}