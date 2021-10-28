using System.Text.RegularExpressions;
using System.Collections.Generic;
using System;

namespace tokenizer
{
public class Grammar
  {
    public List<RegexRule> RegexRules { get; } = new List<RegexRule>();

    public KeyValuePair<string, string> MatchAllrules(string characters)
    {
      string match = "";
      string token = "";
      Regex reg = null;

      foreach (RegexRule rule in RegexRules)
      {
        if (rule.RegexPattern.Match(characters).Length > match.Length)
        {
          match = rule.RegexPattern.Match(characters).ToString();
          token = rule.TokenType;
          reg = rule.RegexPattern;
        }
      }

      ThrowErrorOnNoMatch(reg, characters);

      if (characters.Length == 0)
      {
        return new KeyValuePair<string, string>("END", "");
      }

      return new KeyValuePair<string, string>(token, match);
    }

    public void ThrowErrorOnNoMatch(Regex reg, string characters)
    {
      if (reg == null && characters.Length > 0)
      {
        throw new Exception("No lexical element matches '" + characters[0] + "'.");
      }
    }
    public void Add(RegexRule rule)
    {
      RegexRules.Add(rule);
    }
  }
}