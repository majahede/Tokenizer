using System;
using System.Collections.Generic;
using tokenizer;
using Xunit;

public class MaximalMunchGrammarTest
{
    public Grammar GetMaximalMunchGrammar() {
      Grammar maximalMunchGrammar  = new Grammar();
      RegexRule regexRule = new RegexRule("FLOAT", "^[0-9]+\\.[0-9]+");
      maximalMunchGrammar.Add(regexRule);
      regexRule = new RegexRule("INTEGER", "^[0-9]+");
      maximalMunchGrammar.Add(regexRule);

      return maximalMunchGrammar;
    }

    [Fact]
    public void TC1()
    {
    Tokenizer t = new Tokenizer(GetMaximalMunchGrammar(), "3.14");

    Assert.Equal("FLOAT", t.GetActiveToken().Token);
    Assert.Equal("3.14", t.GetActiveToken().Match);
    }

    [Fact]
    public void TC2()
    {
    Tokenizer t = new Tokenizer(GetMaximalMunchGrammar(), "3");

    Assert.Equal("INTEGER", t.GetActiveToken().Token);
    Assert.Equal("3", t.GetActiveToken().Match);
    }

    [Fact]
    public void TC3()
    {
    Tokenizer t = new Tokenizer(GetMaximalMunchGrammar(), "3.14 6 4.5");
    t.GetActiveToken();
    t.GetNextToken();
    t.GetNextToken();

    Assert.Equal("FLOAT", t.GetActiveToken().Token);
    Assert.Equal("4.5", t.GetActiveToken().Match);
    }

    [Fact]
    public void TC4()
    {
    Tokenizer t = new Tokenizer(GetMaximalMunchGrammar(), "5     10 6.4");
    t.GetActiveToken();
    t.GetNextToken();
    t.GetNextToken();
    t.GetPreviousToken();

    Assert.Equal("INTEGER", t.GetActiveToken().Token);
    Assert.Equal("10", t.GetActiveToken().Match);
    }

    [Fact]
    public void TC5()
    {
    Tokenizer t = new Tokenizer(GetMaximalMunchGrammar(), "5.6 + 10");
    t.GetActiveToken();
    Assert.Throws<Exception>(() => t.GetNextToken());
    }
}