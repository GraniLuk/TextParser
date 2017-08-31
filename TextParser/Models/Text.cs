using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [XmlArray("Sentences")]
        [XmlArrayItem("Sentece")]
        public List<Sentence> Sentences => new Parsers.TextParser(Input).GetSenteces();
        [XmlIgnore]
        [DataType(DataType.MultilineText)]
        public string Input { get; set; }

        public string ParseTo(IParser parser)
        {
            return parser.Parse(this);
        }
    }
}