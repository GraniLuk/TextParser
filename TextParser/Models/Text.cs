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
        /// <remarks/>
        [XmlArray("Sentences")]
        [XmlArrayItem("Sentece")]
        // [XmlArrayItemAttribute("Sentence", typeof(Sentence), IsNullable = false)]
        public List<Sentence> Sentences { get; set; }
        public string Input { get; set; }
    }

    
}