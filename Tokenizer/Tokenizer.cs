using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace tokenizer
{
public class Tokenizer
  {
  
    private readonly List<TokenMatch> tokens = new List<TokenMatch>();
    private string characters;
    private int activeTokenIndex = 0;
    private readonly Grammar grammar;

    public Tokenizer(Grammar grammar, string characters)
    {
      this.grammar = grammar;
      this.characters = characters.TrimStart();
    }

    /// <summary>
    /// Looks for the tokenmatch for a string.
    /// </summary>
    private void GetTokenMatch()
    {
      var tokenMatch = grammar.MatchAllRules(characters);
      AddTokenMatch(tokenMatch);
    }

    /// <summary>
    /// Adds the token and matching string to a list.
    /// </summary>
    private void AddTokenMatch(TokenMatch tokenMatch)
    {
      characters = characters[tokenMatch.Match.Length..].TrimStart();
      tokens.Add(tokenMatch);
    }

    public TokenMatch GetActiveToken()
    {
      if (tokens.Count <= activeTokenIndex)
      {
        GetTokenMatch();

        return tokens[activeTokenIndex];
      }
      else
      {
        return tokens[activeTokenIndex];
      }
    }

    public TokenMatch GetNextToken()
    {
      ThrowErrorOnEndOfString();
      activeTokenIndex++;
      return GetActiveToken();
    }

    public TokenMatch GetPreviousToken()
    {
      activeTokenIndex--;
      ThrowErrorOnStartOfString();
      return GetActiveToken();
    }

    public void ThrowErrorOnNoMatch(Regex reg)
    {
      if (reg == null && characters.Length > 0)
      {
        throw new Exception("No lexical element matches '" + characters[0] + "'.");
      }
    }

    public void ThrowErrorOnEndOfString()
    {
      if (GetActiveToken().Token == "END")
      {
        throw new IndexOutOfRangeException("You have reached the end of the string.");
      }
    }

    public void ThrowErrorOnStartOfString()
    {
      if (activeTokenIndex < 0)
      {
        throw new IndexOutOfRangeException("You have reached the start of the string.");
      }
    }
  }

}