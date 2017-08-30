using System.IO;
using System.Xml.Serialization;
using TextParser.Models;

namespace TextParser.Parsers
{
    public class XmlParser : IParser
    {
        public string Parse(Text text)
        {
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            var serializer = new XmlSerializer(typeof(Text), new XmlRootAttribute(nameof(Text)));
            using (var textWriter = new StringWriter())
            {
                serializer.Serialize(textWriter, text, ns);
                return textWriter.ToString();
            }
        }
    }
}