using System.IO;
using System.Xml.Serialization;

namespace TextParser.Models
{
    public class XmlSerializer
    {
        public string Serialize(Text text)
        {
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "");
            var serializer = new System.Xml.Serialization.XmlSerializer(typeof(Text), new XmlRootAttribute(nameof(Text)));
            using (var textWriter = new StringWriter())
            {
                serializer.Serialize(textWriter, text,ns);
                return textWriter.ToString();
            }
        }
    }
}