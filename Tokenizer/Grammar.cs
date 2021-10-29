using System.Text.RegularExpressions;
using System.Collections.Generic;
using System;

namespace tokenizer
{
public class Grammar
  {
    public List<RegexRule> RegexRules { get; } = new List<RegexRule>();

    public TokenMatch MatchAllRules(string characters)
    {
      TokenMatch tokenMatch = new TokenMatch();

      bool isMatch = false;

      foreach (RegexRule rule in RegexRules)
      {
        if (rule.RegexPattern.Match(characters).Length > tokenMatch.Match.Length)
        {
            tokenMatch.Match = rule.RegexPattern.Match(characters).ToString();
            tokenMatch.Token = rule.TokenType;
            isMatch = true;
        }
      }

      ThrowErrorOnNoMatch(isMatch, characters);
      return tokenMatch;
    }

    public void ThrowErrorOnNoMatch(bool isMatch, string characters)
    {
      if (!isMatch && characters.Length > 0)
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