using System.ComponentModel.DataAnnotations;

namespace TextParser.Models
{
    public class InputForm
    {
        [DataType(DataType.MultilineText)]
        public string Input { get; set; }
    }
}