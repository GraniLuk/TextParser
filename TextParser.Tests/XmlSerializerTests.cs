using System.Collections.Generic;
using NUnit.Framework;
using TextParser.Models;
using TextParser.Parsers;

namespace TextParser.Tests
{
    [TestFixture]
    public class XmlParserTests
    {
        [Test]
        public void SerializeSimpleClassText()
        {
            var text = new Text("") {Sentences = new List<Sentence>(){ new Sentence() {Words = new List<string>() {"a", "had", "lamb", "little", "Mary"}}}};

            const string expected = "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<Text>\r\n  <Sentences>\r\n    <Sentece>\r\n      <Words>\r\n        <Word>a</Word>\r\n        <Word>had</Word>\r\n        <Word>lamb</Word>\r\n        <Word>little</Word>\r\n        <Word>Mary</Word>\r\n      </Words>\r\n    </Sentece>\r\n  </Sentences>\r\n</Text>";

            var result = new XmlParser(text).Parse();

            Assert.AreEqual(expected,result);
        }

        [Test]
        public void SerializeClassToGetExampleString()
        {
            var text = new Text("")
            {
                Sentences = new List<Sentence>()
                {
                    new Sentence() { Words = new List<string>() { "a", "had", "lamb", "little", "Mary" } },
                    new Sentence() { Words = new List<string>() { "Aesop", "and", "called", "came", "for", "Peter", "the", "wolf" } },
                    new Sentence() { Words = new List<string>() { "Cinderella", "likes", "shoes"} }
                }
            };

            var expected = Properties.Examples.xmlResult;

            var result = new XmlParser(text).Parse();

            Assert.AreEqual(expected, result);
        }


    }
}
