using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace tokenizer
{
public class Tokenizer
  {

    private readonly List<TokenMatch> tokens = new List<TokenMatch>();
    private string characters;
    private int activeTokenIndex;
    private readonly Grammar grammar;

    public TokenMatch ActiveToken => GetActiveToken(activeTokenIndex);

    public Tokenizer(Grammar grammar, string characters)
    {
      this.grammar = grammar;
      this.characters = characters.TrimStart();
    }

    private void GetTokenMatch()
    {
      var tokenMatch = grammar.MatchAllRules(characters);
      AddTokenMatch(tokenMatch);
    }

    private void AddTokenMatch(TokenMatch tokenMatch)
    {
      characters = characters[tokenMatch.Match.Length..].TrimStart();
      tokens.Add(tokenMatch);
    }

    public TokenMatch GetActiveToken(int index)
    {
      if (tokens.Count <= index)
      {
        GetTokenMatch();
      }

     ThrowErrorOnStartOfString();
     ThrowErrorOnEndOfString();

     return tokens[index];
    }

    public void GetNextToken() => activeTokenIndex++;

    public void GetPreviousToken() => activeTokenIndex--;

    public void ThrowErrorOnEndOfString()
    {
      if (tokens.Count > 2 && tokens[activeTokenIndex - 1].Token == "END")
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