using System.Dynamic;
using System.Text.RegularExpressions;
using System.Xml.Schema;
using Xunit.Sdk;

namespace tokenizer
{
    public class RegexRule
    {
        public string RegexPattern { get; }
        public string TokenType { get; }

        public RegexRule(string tokenType, string regexPattern)
        {
          TokenType = tokenType;
          RegexPattern = regexPattern;
        }
    }
}

// någon error handling?