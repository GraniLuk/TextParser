﻿using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using NUnit.Framework;

namespace TextParser.Tests
{
    [TestFixture]
    public class XmlParserTests
    {
        [Test]
        public void SerializeSimpleClassText()
        {
            var text = new Text {Sentences = new List<Sentence>(){ new Sentence() {Words = new List<string>() {"a", "had", "lamb", "little", "Mary"}}}};

            const string expected = "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<Text>\r\n  <Sentences>\r\n    <Sentece>\r\n      <Words>\r\n        <Word>a</Word>\r\n        <Word>had</Word>\r\n        <Word>lamb</Word>\r\n        <Word>little</Word>\r\n        <Word>Mary</Word>\r\n      </Words>\r\n    </Sentece>\r\n  </Sentences>\r\n</Text>";

            var xmlParser = new XmlSerializer();

            var result = xmlParser.Serialize(text);

            Assert.AreEqual(expected,result);
        }

        [Test]
        public void SerializeClassToGetExampleString()
        {
            var text = new Text()
            {
                Sentences = new List<Sentence>()
                {
                    new Sentence() { Words = new List<string>() { "a", "had", "lamb", "little", "Mary" } },
                    new Sentence() { Words = new List<string>() { "Aesop", "and", "called", "came", "for", "Peter", "the", "wolf" } },
                    new Sentence() { Words = new List<string>() { "Cinderella", "likes", "shoes"} }
                }
            };

            var expected = Properties.Examples.xmlResult;

            var xmlParser = new XmlSerializer();

            var result = xmlParser.Serialize(text);

            Assert.AreEqual(expected, result);
        }


    }
}
