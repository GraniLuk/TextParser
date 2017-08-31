using System.Text;
using System.Xml.Serialization;
using TextParser.Extensions;
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
            using (var textWriter = new StringWriterWithEncoding(Encoding.UTF8))
            {
                serializer.Serialize(textWriter, text, ns);
                return textWriter.ToString();
            }
        }
    }
}