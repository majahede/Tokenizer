using System.Text.RegularExpressions;

namespace tokenizer
{
    public class RegexRule
    {
        private readonly string regexPattern;

        public string TokenType { get; }
        public Regex RegexPattern  => new Regex(regexPattern);

        public RegexRule(string tokenType, string regexPattern)
            {
              TokenType = tokenType;
              this.regexPattern = regexPattern;
            }

        public bool IsMatch(string characters) {
            return RegexPattern.IsMatch(characters);
        }
    }
}

// någon error handling?