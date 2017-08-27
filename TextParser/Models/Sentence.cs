using System.Collections.Generic;
using System.Xml.Serialization;

namespace TextParser.Models
{
    public class Sentence
    {
        public Sentence()
        {
            Words = new List<string>();
        }
        [XmlArray("Words")]
        [XmlArrayItem("Word")]
        public List<string> Words { get; set; }
    }
}