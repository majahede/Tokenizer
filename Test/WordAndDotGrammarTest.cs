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

    [Fact]
    public void TC1()
    {
      Tokenizer t = new Tokenizer(GetWordAndDotGrammar(), "a");

      Assert.Equal("WORD", t.GetActiveToken().Token);
      Assert.Equal("a", t.GetActiveToken().Match);
    }

    [Fact]
    public void TC2()
    {
      Tokenizer t = new Tokenizer(GetWordAndDotGrammar(), "a aa");
      t.GetActiveToken();
      t.GetNextToken();

      Assert.Equal("WORD", t.GetActiveToken().Token);
      Assert.Equal("aa", t.GetActiveToken().Match);
    }

    [Fact]
    public void TC3()
    {
      Tokenizer t = new Tokenizer(GetWordAndDotGrammar(), "a.b");
      t.GetActiveToken();
      t.GetNextToken();

      Assert.Equal("DOT", t.GetActiveToken().Token);
      Assert.Equal(".", t.GetActiveToken().Match);
    }

    [Fact]
    public void TC4()
    {
     Tokenizer t = new Tokenizer(GetWordAndDotGrammar(), "a.b");
      t.GetActiveToken();
      t.GetNextToken();
      t.GetNextToken();

      Assert.Equal("WORD", t.GetActiveToken().Token);
      Assert.Equal("b", t.GetActiveToken().Match);
    }

    [Fact]
    public void TC5()
    {
     Tokenizer t = new Tokenizer(GetWordAndDotGrammar(), "aa. b");
      t.GetActiveToken();
      t.GetNextToken();
      t.GetNextToken();

      Assert.Equal("WORD", t.GetActiveToken().Token);
      Assert.Equal("b", t.GetActiveToken().Match);
    }

    [Fact]
    public void TC6()
    {
     Tokenizer t = new Tokenizer(GetWordAndDotGrammar(), "a .b");
      t.GetActiveToken();
      t.GetNextToken();
      t.GetNextToken();
      t.GetPreviousToken();
      Assert.Equal("DOT", t.GetActiveToken().Token);
      Assert.Equal(".", t.GetActiveToken().Match);
    }

    [Fact]
    public void TC7()
    {
     Tokenizer t = new Tokenizer(GetWordAndDotGrammar(), "");
      Assert.Equal("END", t.GetActiveToken().Token);
    }

    [Fact]
    public void TC8()
    {
     Tokenizer t = new Tokenizer(GetWordAndDotGrammar(), " ");
     Assert.Equal("END", t.GetActiveToken().Token);
    }

    [Fact]
    public void TC9()
    {
    Tokenizer t = new Tokenizer(GetWordAndDotGrammar(), "a");
     t.GetActiveToken();
     t.GetNextToken();
     Assert.Equal("END", t.GetActiveToken().Token);
     Assert.Equal("", t.GetActiveToken().Match);
    }

    [Fact]
    public void TC10()
    {
     Tokenizer t = new Tokenizer(GetWordAndDotGrammar(), "a");
     t.GetActiveToken();
     Assert.Throws<IndexOutOfRangeException>(() => t.GetPreviousToken());
    }

    [Fact]
    public void TC11()
    {
    Tokenizer t = new Tokenizer(GetWordAndDotGrammar(), "!");
    Assert.Throws<Exception>(() => t.GetActiveToken());
    }

    [Fact]
    public void TC12()
    {
    Tokenizer t = new Tokenizer(GetWordAndDotGrammar(), "aa a");
    t.GetActiveToken();
    t.GetNextToken();
    t.GetNextToken();
    Assert.Throws<IndexOutOfRangeException>(() => t.GetNextToken());
    }

    [Fact]
    public void TC13()
    {
    Tokenizer t = new Tokenizer(GetWordAndDotGrammar(), "aa a");
    t.GetActiveToken();
    Assert.Throws<IndexOutOfRangeException>(() => t.GetPreviousToken());
    }
}