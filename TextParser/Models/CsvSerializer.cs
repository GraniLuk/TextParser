using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace TextParser.Models
{
    public class CsvSerializer
    {
        private readonly Text _text;

        public CsvSerializer(Text text)
        {
            _text = text;
        }
        public string Serialize(string separator = ",", bool header = true)
        {
            var result = string.Empty;
            if (header)
            {
                result += GetHeader(separator);
                result += Environment.NewLine;
            }

            result += string.Join(Environment.NewLine, _text.Sentences.Select(
                (sentence, index) => nameof(Sentence) + " " + (index + 1) + separator + string.Join(separator, sentence
                                         .Words
                                         .Select(f => " " + Regex.Replace(
                                                          Convert.ToString(f.ToString()),
                                                          @"\t|\n|\r", "").Trim())
                                         .ToArray())));

            return result;
        }

        public string GetHeader(string separator = ",")
        {
            const string headerName = " Word ";
            var sentenceWithMostWords = _text.Sentences.OrderByDescending(a => a.Words.Count).FirstOrDefault();
            return sentenceWithMostWords != null ? 
                separator + string.Join(separator, sentenceWithMostWords.Words.Select((value, index) =>
                headerName+ (index + 1))) 
                : string.Empty;
        }
    }
}
