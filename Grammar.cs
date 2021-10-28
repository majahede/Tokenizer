using System.Text.RegularExpressions;
using System.Collections.Generic;
using System;

public class Grammar 
{
    private readonly Dictionary<string, Regex> grammar = new Dictionary<string, Regex>();

    public KeyValuePair<string, string> MatchAllrules(string tokenString) {
        string matchingString = "";
        string token = "";
        Regex reg = null;

        foreach ( KeyValuePair<string, Regex> rgx in grammar)
          {
          if (rgx.Value.Match(tokenString).Length > matchingString.Length)
          {
            matchingString = rgx.Value.Match(tokenString).ToString();
            token = rgx.Key;
            reg = rgx.Value;
          }
        }

      ThrowErrorOnNoMatch(reg, tokenString);

      if(tokenString.Length == 0)
        {
            return new KeyValuePair<string, string>("END", "");
        }

      return new KeyValuePair<string, string>(token, matchingString);
    }

     public void ThrowErrorOnNoMatch(Regex reg, string tokenString) {
        if(reg == null && tokenString.Length > 0)
        {
          throw new Exception("No lexical element matches '" + tokenString[0] + "'." );
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
