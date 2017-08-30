using System.IO;
using System.Xml.Serialization;
using TextParser.Models;

namespace TextParser.Parsers
{
    public class XmlParser
    {
        private readonly Text _text;

        public XmlParser(Text text)
        {
            _text = text;
        }
        public string Parse()
        {
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            var serializer = new XmlSerializer(typeof(Text), new XmlRootAttribute(nameof(Text)));
            using (var textWriter = new StringWriter())
            {
                serializer.Serialize(textWriter, _text,ns);
                return textWriter.ToString();
            }
        }
    }
}