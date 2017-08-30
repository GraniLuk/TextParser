using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using TextParser.Parsers;

namespace TextParser.Models
{
    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class Text
    {
        public Text()
        {
            
        }
        public Text(string input)
        {
            Sentences = new Parsers.TextParser(input).GetSenteces();
        }
        [XmlArray("Sentences")]
        [XmlArrayItem("Sentece")]
        public List<Sentence> Sentences { get; set; }

        public string ToXml()
        {
            return new XmlParser(this).Parse();
        }

        public string ToCsv()
        {
            return new CsvParser(this).Parse();
        }
    }

    
}