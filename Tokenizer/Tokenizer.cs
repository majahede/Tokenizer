using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;

// något du kan fundera på är om du skulle kunna tillföra något genom att få fler klasser. 
// Exempelvis TokenType (eller RegexRule) och TokenMatch 
// samt om Grammar skulle kunna få mer ansvar än att bara vara en samling?
namespace tokenizer {

public class Tokenizer
{
    private readonly List<KeyValuePair<string, string>> tokens = new List<KeyValuePair<string, string>>();
    private readonly Dictionary<string, Regex> regexRules;
    private string tokenString;
    private int activeTokenIndex = 0;
    private Grammar grammar;

    public Tokenizer (Grammar grammar, string tokenString)
    {
        this.grammar = grammar;
        regexRules = grammar.GetGrammar();
        this.tokenString = tokenString.TrimStart();
    }

    /// <summary>
    /// Looks for the tokenmatch for a string.
    /// </summary>
    private void GetTokenMatch()
    {
        var match = grammar.MatchAllrules(tokenString);
        AddTokenMatch(match);
    }

    /// <summary>
    /// Adds the token and matching string to a list.
    /// </summary>
    private void AddTokenMatch(KeyValuePair<string, string> match) 
    {
        tokenString = tokenString[match.Value.Length..].TrimStart();
        tokens.Add(match);
    }

    public KeyValuePair<string, string> GetActiveToken()
    {
        if(tokens.Count <= activeTokenIndex)
        {
            GetTokenMatch();

            return tokens[activeTokenIndex];
        } else
        {
            return tokens[activeTokenIndex];
        }
    }

    public KeyValuePair<string, string> GetNextToken()
    {
        ThrowErrorOnEndOfString();
        activeTokenIndex++;
        return GetActiveToken();
    }

    public KeyValuePair<string, string> GetPreviousToken()
    {
        activeTokenIndex--;
        ThrowErrorOnStartOfString();
        return GetActiveToken();
    }
// test
    public void ThrowErrorOnNoMatch(Regex reg)
        {
            if (reg == null && tokenString.Length > 0)
            {
                throw new Exception("No lexical element matches '" + tokenString[0] + "'.");
            }
        }

        public void ThrowErrorOnEndOfString()
        {
            if (GetActiveToken().Key == "END")
            {
                throw new IndexOutOfRangeException("You have reached the end of the string.");
            }
        }

     public void ThrowErrorOnStartOfString() {
      if(activeTokenIndex < 0 )
        {
            throw new IndexOutOfRangeException("You have reached the start of the string.");
        }
    }
}
}