using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;
using TextParser.Models;

namespace TextParser.Tests
{
    [TestFixture()]
    class InputParserTests
    {
        [Test]
        public void CreateTextClassFromStringInput()
        {
            const string input = "Mary had a little lamb. Peter called for the wolf, and Aesop came. \r\nCinderella likes shoes.\r\n";

            var expected = new Text()
            {
                Sentences = new List<Sentence>()
                    {
                        new Sentence() { Words = new List<string>() { "a", "had", "lamb", "little", "Mary" } },
                        new Sentence() { Words = new List<string>() { "Aesop", "and", "called", "came", "for", "Peter", "the", "wolf" } },
                        new Sentence() { Words = new List<string>() { "Cinderella", "likes", "shoes"} }
                    }
            };

            var inputParser = new InputParser();
            var result = inputParser.Parse(input);

            for (var i = 0; i < expected.Sentences.Count; i++)
            {
                Assert.AreEqual(expected.Sentences[i].Words, result.Sentences[i].Words);
            }
           
        }

        [Test]
        public void CreateTextClassFromStringInputWithSpacesAndNewLines()
        {
            const string input = "  Mary   had a little  lamb  . \r\n\r\n\r\n  Peter   called for the wolf   ,  and Aesop came .\r\n Cinderella  likes shoes.\r\n";

            var expected = new Text()
            {
                Sentences = new List<Sentence>()
                {
                    new Sentence() { Words = new List<string>() { "a", "had", "lamb", "little", "Mary" } },
                    new Sentence() { Words = new List<string>() { "Aesop", "and", "called", "came", "for", "Peter", "the", "wolf" } },
                    new Sentence() { Words = new List<string>() { "Cinderella", "likes", "shoes"} }
                }
            };

            var inputParser = new InputParser();
            var result = inputParser.Parse(input);

            for (var i = 0; i < expected.Sentences.Count; i++)
            {
                Assert.AreEqual(expected.Sentences[i].Words, result.Sentences[i].Words);
            }

        }

        [Test]
        public void CreateTextClassFromStringInputWithSpacesAndNewLinesCheckAmountOfSentences_Returns3()
        {
            const string input = "\"  Mary   had a little  lamb  . \r\n\r\n\r\n  Peter   called for the wolf   ,  and Aesop came .\r\n Cinderella  likes shoes.\r\n";

            var expected = 3;

            var inputParser = new InputParser();
            var result = inputParser.Parse(input);

            Assert.AreEqual(expected, result.Sentences.Count);

        }

        [Test]
        public void CreateTextClassFromStringInputWithOnlyOneSentence()
        {
            const string input = "Mary had a little lamb.";

            var expected = new Text()
            {
                Sentences = new List<Sentence>()
                {
                    new Sentence() { Words = new List<string>() { "a", "had", "lamb", "little", "Mary" } }
                }
            };

            var inputParser = new InputParser();
            var result = inputParser.Parse(input);

            Assert.AreEqual(expected.Sentences[0].Words, result.Sentences[0].Words);
        }

        [Test]
        public void CheckAmountOfSentences_Returns3()
        {
            const string input = "Mary had a little lamb. Peter called for the wolf, and Aesop came. \r\nCinderella likes shoes.\r\n";

            const int expected = 3;

            var inputParser = new InputParser();
            var result = inputParser.Parse(input);

            Assert.AreEqual(expected, result.Sentences.Count);
        }
    }

    internal class InputParser
    {
        public Text Parse(string input)
        {
            const char sentenceDelimiter = '.';
            var text = new Text();
            foreach (var sentence in input.Split(sentenceDelimiter).ToList())
            {
                if (string.IsNullOrWhiteSpace(sentence)) continue;
                const char wordDelimiter = ' ';
                var newSentence = new Sentence();
                foreach (var word in sentence.Split(wordDelimiter).ToList().OrderBy(x=>x.ToString()))
                {
                    var wordWithoutDelimiterAndWhiteSpaces = Regex.Replace(word, @"\t|\n|\r|,", "");
                    if (string.IsNullOrEmpty(wordWithoutDelimiterAndWhiteSpaces)) continue;
                    newSentence.Words.Add(wordWithoutDelimiterAndWhiteSpaces);
                }
                text.Sentences.Add(newSentence);
            }
            return text;
        }
    }
}
