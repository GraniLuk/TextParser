using System.Collections.Generic;
using System.Xml.Serialization;

namespace TextParser.Tests
{
    public class Sentence
    {
        [XmlArray("Words")]
        [XmlArrayItem("Word")]
        public List<string> Words { get; set; }
    }
}