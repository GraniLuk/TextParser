using System.IO;
using System.Xml.Serialization;

namespace TextParser.Models
{
    public class XmlSerializer
    {
        private readonly Text _text;

        public XmlSerializer(Text text)
        {
            _text = text;
        }
        public string Serialize()
        {
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(Text), new XmlRootAttribute(nameof(Text)));
            using (var textWriter = new StringWriter())
            {
                serializer.Serialize(textWriter, _text,ns);
                return textWriter.ToString();
            }
        }
    }
}