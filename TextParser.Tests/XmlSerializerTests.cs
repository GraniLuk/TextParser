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
            var text = new Text() {Input = "Mary had a little lamb."};

            const string expected = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<Text>\r\n  <Sentences>\r\n    <Sentece>\r\n      <Words>\r\n        <Word>a</Word>\r\n        <Word>had</Word>\r\n        <Word>lamb</Word>\r\n        <Word>little</Word>\r\n        <Word>Mary</Word>\r\n      </Words>\r\n    </Sentece>\r\n  </Sentences>\r\n</Text>";

            var result = text.ParseTo(new XmlParser());

            Assert.AreEqual(expected,result);
        }

        [Test]
        public void SerializeClassToGetExampleString()
        {
            var text = new Text()
            {
                Input =
                    "Mary had a little lamb. Peter called for the wolf, and Aesop came. \r\nCinderella likes shoes.\r\n"
            };

            var expected = Properties.Examples.xmlResult;

            var result = text.ParseTo(new XmlParser());

            Assert.AreEqual(expected, result);
        }


    }
}
