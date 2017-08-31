using System.Collections.Generic;
using NUnit.Framework;
using TextParser.Models;
using TextParser.Parsers;

namespace TextParser.Tests
{
    [TestFixture]
    internal class CsvSerializerTests
    {
        [Test]
        public void ParseSimleClassToCsv()
        {
            var text = new Text() {Input = "Mary had a little lamb."};

            const string expected =
                ", Word 1, Word 2, Word 3, Word 4, Word 5\r\nSentence 1, a, had, lamb, little, Mary";

            var result = text.ParseTo(new CsvParser());

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ParseFullExampleToCsv()
        {
            var text = new Text()
            {
                Input =
                    "Mary had a little lamb. Peter called for the wolf, and Aesop came. \r\nCinderella likes shoes.\r\n"
            };

            const string expected =
                ", Word 1, Word 2, Word 3, Word 4, Word 5, Word 6, Word 7, Word 8\r\nSentence 1, a, had, lamb, little, Mary\r\nSentence 2, Aesop, and, called, came, for, Peter, the, wolf\r\nSentence 3, Cinderella, likes, shoes";

            var result = text.ParseTo(new CsvParser());

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetHeader()
        {
            var text = new Text() { Input = "Mary had a little lamb." };

            const string expected = ", Word 1, Word 2, Word 3, Word 4, Word 5";

            var result = new CsvParser().GetHeader(text);

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetHeaderForLongestSentenceInTheMiddle()
        {
            var text = new Text()
            {
                Input =
                    "Mary had a little lamb. Peter called for the wolf, and Aesop came. \r\nCinderella likes shoes.\r\n"
            };

            const string expected = ", Word 1, Word 2, Word 3, Word 4, Word 5, Word 6, Word 7, Word 8";

            var result = new CsvParser().GetHeader(text);

            Assert.AreEqual(expected, result);
        }
    }
}