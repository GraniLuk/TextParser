using System.Collections.Generic;
using NUnit.Framework;
using TextParser.Models;

namespace TextParser.Tests
{
    [TestFixture()]
    internal class InputParserTests
    {
        [Test]
        public void CreateTextClassFromStringInput()
        {
            const string input = "Mary had a little lamb. Peter called for the wolf, and Aesop came. \r\nCinderella likes shoes.\r\n";

            var expected = new Text("")
            {
                Sentences = new List<Sentence>()
                    {
                        new Sentence() { Words = new List<string>() { "a", "had", "lamb", "little", "Mary" } },
                        new Sentence() { Words = new List<string>() { "Aesop", "and", "called", "came", "for", "Peter", "the", "wolf" } },
                        new Sentence() { Words = new List<string>() { "Cinderella", "likes", "shoes"} }
                    }
            };

            var result = new Text(input);

            for (var i = 0; i < expected.Sentences.Count; i++)
            {
                Assert.AreEqual(expected.Sentences[i].Words, result.Sentences[i].Words);
            }
           
        }

        [Test]
        public void CreateTextClassFromStringInputWithSpacesAndNewLines()
        {
            const string input = "  Mary   had a little  lamb  . \r\n\r\n\r\n  Peter   called for the wolf   ,  and Aesop came .\r\n Cinderella  likes shoes.\r\n";

            var expected = new Text("")
            {
                Sentences = new List<Sentence>()
                {
                    new Sentence() { Words = new List<string>() { "a", "had", "lamb", "little", "Mary" } },
                    new Sentence() { Words = new List<string>() { "Aesop", "and", "called", "came", "for", "Peter", "the", "wolf" } },
                    new Sentence() { Words = new List<string>() { "Cinderella", "likes", "shoes"} }
                }
            };

            var result = new Text(input);

            for (var i = 0; i < expected.Sentences.Count; i++)
            {
                Assert.AreEqual(expected.Sentences[i].Words, result.Sentences[i].Words);
            }

        }

        [Test]
        public void CreateTextClassFromStringInputWithSpacesAndNewLinesCheckAmountOfSentences_Returns3()
        {
            const string input = "\"  Mary   had a little  lamb  . \r\n\r\n\r\n  Peter   called for the wolf   ,  and Aesop came .\r\n Cinderella  likes shoes.\r\n";

            const int expected = 3;

            var result = new Text(input);

            Assert.AreEqual(expected, result.Sentences.Count);

        }

        [Test]
        public void CreateTextClassFromStringInputWithOnlyOneSentence()
        {
            const string input = "Mary had a little lamb.";

            var expected = new Text("")
            {
                Sentences = new List<Sentence>()
                {
                    new Sentence() { Words = new List<string>() { "a", "had", "lamb", "little", "Mary" } }
                }
            };

            var result = new Text(input);

            Assert.AreEqual(expected.Sentences[0].Words, result.Sentences[0].Words);
        }

        [Test]
        public void CheckAmountOfSentences_Returns3()
        {
            const string input = "Mary had a little lamb. Peter called for the wolf, and Aesop came. \r\nCinderella likes shoes.\r\n";

            const int expected = 3;

            var result = new Text(input);

            Assert.AreEqual(expected, result.Sentences.Count);
        }
    }
}
