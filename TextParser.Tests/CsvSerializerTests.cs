using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TextParser.Tests
{
    [TestFixture]
    class CsvSerializerTests
    {
        [Test]
        public void ParseSimleClassToCsv()
        {
            var text = new Text { Sentences = new List<Sentence>() { new Sentence() { Words = new List<string>() { "a", "had", "lamb", "little", "Mary" } } } };

            const string expected = "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<Text>\r\n  <Sentences>\r\n    <Sentece>\r\n      <Words>\r\n        <Word>a</Word>\r\n        <Word>had</Word>\r\n        <Word>lamb</Word>\r\n        <Word>little</Word>\r\n        <Word>Mary</Word>\r\n      </Words>\r\n    </Sentece>\r\n  </Sentences>\r\n</Text>";

            var xmlParser = new CsvSerializer();

            var result = CsvSerializer.Serialize(text,",",true);

            Assert.AreEqual(expected, result);
        }

        public class CsvSerializer
        {
            public static IEnumerable<string> Serialize<T>(IEnumerable<T> objectlist, string separator = ",",
                bool header = true)
            {
                var fields = typeof(T).GetFields();
                var properties = typeof(T).GetProperties();

                if (header)
                {
                    var str1 = String.Join(separator,
                        fields.Select(f => f.Name).Concat(properties.Select(p => p.Name)).ToArray());
                    str1 = str1 + Environment.NewLine;
                    yield return str1;
                }
                foreach (var o in objectlist)
                {
                    //regex is to remove any misplaced returns or tabs that would
                    //really mess up a csv conversion.
                    var str2 = string.Join(separator, fields
                        .Select(f => (Regex.Replace(Convert.ToString(f.GetValue(o)), @"\t|\n|\r", "") ?? "").Trim())
                        .Concat(properties.Select(
                            p => (Regex.Replace(Convert.ToString(p.GetValue(o, null)), @"\t|\n|\r", "") ?? "").Trim()))
                        .ToArray());

                    str2 = str2 + Environment.NewLine;
                    yield return str2;
                }
            }
        }
    }
}
