using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TextParser.Models;

namespace TextParser.Parsers
{
    public class StringParser
    {
        private readonly string _input;

        public StringParser(string input)
        {
            _input = input;
        }
            public List<Sentence> GetSenteces()
            {
                const char sentenceDelimiter = '.';
                var sentences = new List<Sentence>();
                foreach (var sentence in _input.Split(sentenceDelimiter).ToList())
                {
                    if (string.IsNullOrWhiteSpace(sentence)) continue;
                    const char wordDelimiter = ' ';
                    var newSentence = new Sentence();
                    foreach (var word in sentence.Split(wordDelimiter).ToList().OrderBy(x => x.ToString()))
                    {
                        var wordWithoutDelimiterAndWhiteSpaces = Regex.Replace(word, @"\t|\n|\r|,", "");
                        if (string.IsNullOrEmpty(wordWithoutDelimiterAndWhiteSpaces)) continue;
                        newSentence.Words.Add(wordWithoutDelimiterAndWhiteSpaces);
                    }
                    sentences.Add(newSentence);
                }
                return sentences;
            }
        }
}