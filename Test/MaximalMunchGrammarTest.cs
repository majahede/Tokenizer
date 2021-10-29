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

    public int GetNext(int steps, Tokenizer t) {
      for (int i = 0; i < steps; i++) {
        _ = t.ActiveToken;
        t.GetNextToken();
      }
      return steps;
    }

    public int GetPrevious(int steps, Tokenizer t) {
      for (int i = 0; i < steps; i++) {
        _ = t.ActiveToken;
        t.GetPreviousToken();
      }
      return steps;
    }

    [Fact]
    public void TC1()
    {
    Tokenizer t = new Tokenizer(GetMaximalMunchGrammar(), "3.14");

    Assert.Equal("FLOAT", t.ActiveToken.Token);
    Assert.Equal("3.14", t.ActiveToken.Match);
    }

    [Fact]
    public void TC2()
    {
    Tokenizer t = new Tokenizer(GetMaximalMunchGrammar(), "3");

    Assert.Equal("INTEGER", t.ActiveToken.Token);
    Assert.Equal("3", t.ActiveToken.Match);
    }

    [Fact]
    public void TC3()
    {
    Tokenizer t = new Tokenizer(GetMaximalMunchGrammar(), "3.14 6 4.5");
    GetNext(2, t);

    Assert.Equal("FLOAT", t.ActiveToken.Token);
    Assert.Equal("4.5", t.ActiveToken.Match);
    }

    [Fact]
    public void TC4()
    {
    Tokenizer t = new Tokenizer(GetMaximalMunchGrammar(), "5     10 6.4");
    GetNext(2, t);
    GetPrevious(1, t);

    Assert.Equal("INTEGER", t.ActiveToken.Token);
    Assert.Equal("10", t.ActiveToken.Match);
    }

    [Fact]
    public void TC5()
    {
    Tokenizer t = new Tokenizer(GetMaximalMunchGrammar(), "5.6 + 10");
    GetNext(1, t);
    Assert.Throws<Exception>(() => t.ActiveToken);
    }
}