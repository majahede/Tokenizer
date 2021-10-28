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

    [Fact]
    public void TC1()
    {
    Tokenizer t = new Tokenizer(GetArithmeticGrammar(), "3");
    
    Assert.Equal("NUMBER", t.GetActiveToken().Token);
    Assert.Equal("3", t.GetActiveToken().Match);
    }

    [Fact]
    public void TC2()
    {
    Tokenizer t = new Tokenizer(GetArithmeticGrammar(), "3.14");

    Assert.Equal("NUMBER", t.GetActiveToken().Token);
    Assert.Equal("3.14", t.GetActiveToken().Match);
    }

    [Fact]
    public void TC3()
    {
    Tokenizer t = new Tokenizer(GetArithmeticGrammar(), "3 + 54 * 4");
    t.GetActiveToken();
    t.GetNextToken();
    t.GetNextToken();
    t.GetNextToken();

    Assert.Equal("MUL", t.GetActiveToken().Token);
    Assert.Equal("*", t.GetActiveToken().Match);
    }

    [Fact]
    public void TC4()
    {
    Tokenizer t = new Tokenizer(GetArithmeticGrammar(), "3+5 # 4");
    t.GetActiveToken();
    t.GetNextToken();
    t.GetNextToken();
    Assert.Throws<Exception>(() => t.GetNextToken());
    }

    [Fact]
    public void TC5()
    {
    Tokenizer t = new Tokenizer(GetArithmeticGrammar(), "3.0+54.1     + 4.2");
    t.GetActiveToken();
    t.GetNextToken();
    t.GetPreviousToken();
    t.GetNextToken();
    t.GetNextToken();
    t.GetNextToken();
    Assert.Equal("ADD", t.GetActiveToken().Token);
    Assert.Equal("+", t.GetActiveToken().Match);
    }

    [Fact]
    public void TC6()
    {
    Tokenizer t = new Tokenizer(GetArithmeticGrammar(), "3 + 5");
    t.GetActiveToken();
    t.GetNextToken();
    t.GetNextToken();
    t.GetNextToken();
    Assert.Throws<IndexOutOfRangeException>(() => t.GetNextToken());
    }

    [Fact]
    public void TC7()
    {
    Tokenizer t = new Tokenizer(GetArithmeticGrammar(), "3+5 4");
    t.GetActiveToken();
    t.GetNextToken();
    t.GetPreviousToken();
    Assert.Throws<IndexOutOfRangeException>(() => t.GetPreviousToken());
    }


}