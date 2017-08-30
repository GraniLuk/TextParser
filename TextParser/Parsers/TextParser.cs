using System.Linq;
using System.Text.RegularExpressions;
using TextParser.Models;

namespace TextParser.Parsers
{
    public class TextParser
    {
        private readonly string _input;

        public TextParser(string input)
        {
            _input = input;
        }
            public Text Parse()
            {
                const char sentenceDelimiter = '.';
                var text = new Text();
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
                    text.Sentences.Add(newSentence);
                }
                return text;
            }
        }
}