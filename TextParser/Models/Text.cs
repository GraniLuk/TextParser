using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace TextParser.Models
{
    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class Text
    {
        public Text(string input)
        {
            Sentences = new List<Sentence>();
        }
        [XmlArray("Sentences")]
        [XmlArrayItem("Sentece")]
        public List<Sentence> Sentences { get; set; }
    }

    
}