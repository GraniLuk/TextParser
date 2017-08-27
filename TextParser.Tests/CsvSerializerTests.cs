using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using TextParser.Models;

namespace TextParser.Tests
{
    [TestFixture]
    class CsvSerializerTests
    {
        [Test]
        public void ParseSimleClassToCsv()
        {
            var text = new Text
            {
                Sentences = new List<Sentence>()
                {
                    new Sentence() {Words = new List<string>() {"a", "had", "lamb", "little", "Mary"}}
                }
            };

            const string expected =
                ", Word 1, Word 2, Word 3, Word 4, Word 5\r\nSentence 1, a, had, lamb, little, Mary";

            var result = new CsvSerializer(text).Serialize();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ParseFullExampleToCsv()
        {
            var text = new Text()
            {
                Sentences = new List<Sentence>()
                {
                    new Sentence() {Words = new List<string>() {"a", "had", "lamb", "little", "Mary"}},
                    new Sentence()
                    {
                        Words = new List<string>() {"Aesop", "and", "called", "came", "for", "Peter", "the", "wolf"}
                    },
                    new Sentence() {Words = new List<string>() {"Cinderella", "likes", "shoes"}}
                }
            };

            const string expected =
                ", Word 1, Word 2, Word 3, Word 4, Word 5, Word 6, Word 7, Word 8\r\nSentence 1, a, had, lamb, little, Mary\r\nSentence 2, Aesop, and, called, came, for, Peter, the, wolf\r\nSentence 3, Cinderella, likes, shoes";

            var result = new CsvSerializer(text).Serialize();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetHeader()
        {
            var text = new Text
            {
                Sentences = new List<Sentence>()
                {
                    new Sentence() {Words = new List<string>() {"a", "had", "lamb", "little", "Mary"}}
                }
            };

            const string expected = ", Word 1, Word 2, Word 3, Word 4, Word 5";

            var result = new CsvSerializer(text).GetHeader();

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetHeaderForLongestSentenceInTheMiddle()
        {
            var text = new Text()
            {
                Sentences = new List<Sentence>()
                {
                    new Sentence() {Words = new List<string>() {"a", "had", "lamb", "little", "Mary"}},
                    new Sentence()
                    {
                        Words = new List<string>() {"Aesop", "and", "called", "came", "for", "Peter", "the", "wolf"}
                    },
                    new Sentence() {Words = new List<string>() {"Cinderella", "likes", "shoes"}}
                }
            };

            const string expected = ", Word 1, Word 2, Word 3, Word 4, Word 5, Word 6, Word 7, Word 8";

            var result = new CsvSerializer(text).GetHeader();

            Assert.AreEqual(expected, result);
        }
    }
}