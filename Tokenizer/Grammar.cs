using System.Text.RegularExpressions;
using System.Collections.Generic;
using System;

namespace tokenizer
{
public class Grammar
  {
    private readonly RegexRule[] regexRules;

    public KeyValuePair<string, string> MatchAllrules(string characters)
    {
      string match = "";
      string token = "";
      Regex reg = null;

      foreach (RegexRule rule in regexRules)
      {
        if (rgx.Value.Match(characters).Length > match.Length)
        {
          match = rgx.Value.Match(characters).ToString();
          token = rgx.Key;
          reg = rgx.Value;
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

    /// <summary>
    /// Adds a token and mathcing regex to grammar.
    /// </summary>
    public void Add(string token, string regex)
    {
      Regex pattern = new Regex(regex);
      grammar.Add(token, pattern);
    }

    public Dictionary<string, Regex> GetGrammar()
    {
      return grammar;
    }
  }
}