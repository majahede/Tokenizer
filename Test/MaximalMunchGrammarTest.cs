using System;
using System.Collections.Generic;
using tokenizer;
using Xunit;

public class MaximalMunchGrammarTest
{
    public Grammar GetMaximalMunchGrammar() {
      Grammar maximalMunchGrammar  = new Grammar();
      maximalMunchGrammar.Add("FLOAT", "^[0-9]+\\.[0-9]+");
      maximalMunchGrammar.Add("INTEGER", "^[0-9]+");
      return maximalMunchGrammar;
    }

    [Fact]
    public void TC1()
    {
    Tokenizer t = new Tokenizer(GetMaximalMunchGrammar(), "3.14");
    Assert.Equal(new KeyValuePair<string, string>("FLOAT", "3.14"), t.GetActiveToken());
    }

    [Fact]
    public void TC2()
    {
    Tokenizer t = new Tokenizer(GetMaximalMunchGrammar(), "3");
    Assert.Equal(new KeyValuePair<string, string>("INTEGER", "3"), t.GetActiveToken());
    }

    [Fact]
    public void TC3()
    {
    Tokenizer t = new Tokenizer(GetMaximalMunchGrammar(), "3.14 6 4.5");
    t.GetActiveToken();
    t.GetNextToken();
    Assert.Equal(new KeyValuePair<string, string>("FLOAT", "4.5"), t.GetNextToken());
    }

    [Fact]
    public void TC4()
    {
    Tokenizer t = new Tokenizer(GetMaximalMunchGrammar(), "5     10 6.4");
    t.GetActiveToken();
    t.GetNextToken();
    t.GetNextToken();
    Assert.Equal(new KeyValuePair<string, string>("INTEGER", "10"), t.GetPreviousToken());
    }

    [Fact]
    public void TC5()
    {
    Tokenizer t = new Tokenizer(GetMaximalMunchGrammar(), "5.6 + 10");
    t.GetActiveToken();
    Assert.Throws<Exception>(() => t.GetNextToken());
    }
}