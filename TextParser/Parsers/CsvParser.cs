using System;
using System.Linq;
using System.Text.RegularExpressions;
using TextParser.Models;

namespace TextParser.Parsers
{
    public class CsvParser : IParser
    {
        private readonly string _separator;
        private readonly bool _header;

        public CsvParser(string separator = ",", bool header = true)
        {
            _separator = separator;
            _header = header;
        }
        public string Parse(Text text)
        {
            var result = string.Empty;
            if (_header)
            {
                result += GetHeader(text, _separator);
                result += Environment.NewLine;
            }

            result += string.Join(Environment.NewLine, text.Sentences.Select(
                (sentence, index) => nameof(Sentence) + " " + (index + 1) + _separator + string.Join(_separator, sentence
                                         .Words
                                         .Select(f => " " + Regex.Replace(
                                                          Convert.ToString(f.ToString()),
                                                          @"\t|\n|\r", "").Trim())
                                         .ToArray())));

            return result;
        }

        public string GetHeader(Text text,string separator = ",")
        {
            const string headerName = " Word ";
            var sentenceWithMostWords = text.Sentences.OrderByDescending(a => a.Words.Count).FirstOrDefault();
            return sentenceWithMostWords != null ? 
                separator + string.Join(_separator, sentenceWithMostWords.Words.Select((value, index) =>
                headerName+ (index + 1))) 
                : string.Empty;
        }
    }
}
