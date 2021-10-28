using System.Text.RegularExpressions;
using System.Collections.Generic;
using System;

namespace tokenizer
{
public class Grammar
  {
    public List<RegexRule> RegexRules { get; } = new List<RegexRule>();

//-------------------------------------------------------
    public TokenMatch MatchAllRules(string characters)
    {
      TokenMatch tokenMatch = new TokenMatch();

      Regex reg = null;

      foreach (RegexRule rule in RegexRules)
      {
        if (rule.RegexPattern.Match(characters).Length > tokenMatch.Match.Length)
        {
            tokenMatch.Match = rule.RegexPattern.Match(characters).ToString(); //"hej"
            tokenMatch.Token = rule.TokenType;  //WORD
            reg = rule.RegexPattern; // ^/åöäd/
        }
      }

      ThrowErrorOnNoMatch(reg, characters);
      return tokenMatch;
    }


//--------------------------------------------------------------
    public void ThrowErrorOnNoMatch(Regex reg, string characters)
    {
      if (reg == null && characters.Length > 0)
      {
        throw new Exception("No lexical element matches '" + characters[0] + "'.");
      }
    }

//-------------------------------------------------------------------------------
    public void Add(RegexRule rule)
    {
      RegexRules.Add(rule);
    }
  }
}