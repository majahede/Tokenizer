using System;
using System.Collections.Generic;
using Xunit;
using tokenizer;

public class WordAndDotGrammarTest
{
    public Grammar GetWordAndDotGrammar() {
      Grammar wordAndDotGrammar  = new Grammar();
      RegexRule r = new RegexRule("WORD", "^[\\w|åäöÅÄÖ]+");
      wordAndDotGrammar.Add(r);
      r = new RegexRule("DOT", "^\\.");
      wordAndDotGrammar.Add(r);

      return wordAndDotGrammar;
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
      Tokenizer t = new Tokenizer(GetWordAndDotGrammar(), "a");

      Assert.Equal("WORD", t.ActiveToken.Token);
      Assert.Equal("a", t.ActiveToken.Match);
    }

    [Fact]
    public void TC2()
    {
      Tokenizer t = new Tokenizer(GetWordAndDotGrammar(), "a aa");
      GetNext(1, t);

      Assert.Equal("WORD", t.ActiveToken.Token);
      Assert.Equal("aa", t.ActiveToken.Match);
    }

    [Fact]
    public void TC3()
    {
      Tokenizer t = new Tokenizer(GetWordAndDotGrammar(), "a.b");
      GetNext(1, t);

      Assert.Equal("DOT", t.ActiveToken.Token);
      Assert.Equal(".", t.ActiveToken.Match);
    }

    [Fact]
    public void TC4()
    {
     Tokenizer t = new Tokenizer(GetWordAndDotGrammar(), "a.b");
     GetNext(2, t);

      Assert.Equal("WORD", t.ActiveToken.Token);
      Assert.Equal("b", t.ActiveToken.Match);
    }

    [Fact]
    public void TC5()
    {
     Tokenizer t = new Tokenizer(GetWordAndDotGrammar(), "aa. b");
      GetNext(2, t);

      Assert.Equal("WORD", t.ActiveToken.Token);
      Assert.Equal("b", t.ActiveToken.Match);
    }

    [Fact]
    public void TC6()
    {
     Tokenizer t = new Tokenizer(GetWordAndDotGrammar(), "a .b");
      GetNext(2, t);
      GetPrevious(1, t);
      Assert.Equal("DOT", t.ActiveToken.Token);
      Assert.Equal(".", t.ActiveToken.Match);
    }

    [Fact]
    public void TC7()
    {
     Tokenizer t = new Tokenizer(GetWordAndDotGrammar(), "");
      Assert.Equal("END", t.ActiveToken.Token);
    }

    [Fact]
    public void TC8()
    {
     Tokenizer t = new Tokenizer(GetWordAndDotGrammar(), " ");
     Assert.Equal("END", t.ActiveToken.Token);
    }

    [Fact]
    public void TC9()
    {
    Tokenizer t = new Tokenizer(GetWordAndDotGrammar(), "a");
     GetNext(1, t);
     Assert.Equal("END", t.ActiveToken.Token);
     Assert.Equal("", t.ActiveToken.Match);
    }

    [Fact]
    public void TC10()
    {
     Tokenizer t = new Tokenizer(GetWordAndDotGrammar(), "a");
     GetPrevious(1, t);
     Assert.Throws<IndexOutOfRangeException>(() => t.ActiveToken);
    }

    [Fact]
    public void TC11()
    {
    Tokenizer t = new Tokenizer(GetWordAndDotGrammar(), "!");
    Assert.Throws<Exception>(() => t.ActiveToken);
    }

    [Fact]
    public void TC12()
    {
    Tokenizer t = new Tokenizer(GetWordAndDotGrammar(), "aa a");
    GetNext(3, t);
    Assert.Throws<IndexOutOfRangeException>(() => t.ActiveToken);
    }

    [Fact]
    public void TC13()
    {
    Tokenizer t = new Tokenizer(GetWordAndDotGrammar(), "aa a");
    GetPrevious(1, t);
    Assert.Throws<IndexOutOfRangeException>(() => t.ActiveToken);
    }
}