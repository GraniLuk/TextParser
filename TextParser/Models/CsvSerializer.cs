using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace TextParser.Models
{
    public class CsvSerializer
    {
        public static string Serialize(Text text, string separator = ",", bool header = true)
        {
            var result = string.Empty;
            if (header)
            {
                result += GetHeader(text, separator);
                result += Environment.NewLine;
            }

            result += string.Join(Environment.NewLine, text.Sentences.Select(
                (sentence, index) => nameof(Sentence) + " " + (index + 1) + "," + string.Join(separator, sentence
                                         .Words
                                         .Select(f => " " + (Regex.Replace(
                                                          Convert.ToString(f.ToString()),
                                                          @"\t|\n|\r", "")).Trim())
                                         .ToArray())));

            return result;
        }

        public static string GetHeader(Text text, string separator = ",")
        {
            var sentenceWithMostWords = text.Sentences.OrderByDescending(a => a.Words.Count).FirstOrDefault();
            return sentenceWithMostWords != null ? "," + string.Join(separator, sentenceWithMostWords.Words.Select((value, index) => " Word " + (index + 1))) : string.Empty;
        }
    }
}
