using System;
using System.Collections.Generic;
using Xunit;
using tokenizer;

public class ArithmeticGrammarTest
{
    public Grammar GetArithmeticGrammar() {
      Grammar arithmeticGrammar  = new Grammar();
       RegexRule r = new RegexRule("NUMBER", "^[0-9]+(\\.([0-9])+)?");
      arithmeticGrammar.Add(r);
      r = new RegexRule("ADD", "^[+]");
      arithmeticGrammar.Add(r);
      r = new RegexRule("MUL", "^[*]");
      arithmeticGrammar.Add(r);

      return arithmeticGrammar;
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
    Tokenizer t = new Tokenizer(GetArithmeticGrammar(), "3");

    Assert.Equal("NUMBER", t.ActiveToken.Token);
    Assert.Equal("3", t.ActiveToken.Match);
    }

    [Fact]
    public void TC2()
    {
    Tokenizer t = new Tokenizer(GetArithmeticGrammar(), "3.14");

    Assert.Equal("NUMBER", t.ActiveToken.Token);
    Assert.Equal("3.14", t.ActiveToken.Match);
    }

    [Fact]
    public void TC3()
    {
    Tokenizer t = new Tokenizer(GetArithmeticGrammar(), "3 + 54 * 4");
    GetNext(3, t);
    Assert.Equal("MUL", t.ActiveToken.Token);
    Assert.Equal("*", t.ActiveToken.Match);
    }

    [Fact]
    public void TC4()
    {
    Tokenizer t = new Tokenizer(GetArithmeticGrammar(), "3+5 # 4");
    GetNext(3, t);
    Assert.Throws<Exception>(() => t.ActiveToken);
    }

    [Fact]
    public void TC5()
    {
    Tokenizer t = new Tokenizer(GetArithmeticGrammar(), "3.0+54.1     + 4.2");
    GetNext(4, t);
    GetPrevious(1, t);
    Assert.Equal("ADD", t.ActiveToken.Token);
    Assert.Equal("+", t.ActiveToken.Match);
    }

    [Fact]
    public void TC6()
    {
    Tokenizer t = new Tokenizer(GetArithmeticGrammar(), "3 + 5");
    GetNext(4, t);
    Assert.Throws<IndexOutOfRangeException>(() => t.ActiveToken);
    }

    [Fact]
    public void TC7()
    {
    Tokenizer t = new Tokenizer(GetArithmeticGrammar(), "3+5 4");
    GetNext(1, t);
    GetPrevious(2, t);
    Assert.Throws<IndexOutOfRangeException>(() => t.ActiveToken);
    }
 }