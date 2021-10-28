using System;
using System.Collections.Generic;
using Xunit;

public class ArithmeticGrammarTest
{
    public Grammar GetArithmeticGrammar() {
      Grammar arithmeticGrammar  = new Grammar();
      arithmeticGrammar.Add("NUMBER", "^[0-9]+(\\.([0-9])+)?");
      arithmeticGrammar.Add("ADD", "^[+]");
      arithmeticGrammar.Add("MUL", "^[*]");
      return arithmeticGrammar;
    }

    [Fact]
    public void TC1()
    {
    Tokenizer t = new Tokenizer(GetArithmeticGrammar(), "3");
    Assert.Equal(new KeyValuePair<string, string>("NUMBER", "3"), t.GetActiveToken());
    }

    [Fact]
    public void TC2()
    {
    Tokenizer t = new Tokenizer(GetArithmeticGrammar(), "3.14");
    Assert.Equal(new KeyValuePair<string, string>("NUMBER", "3.14"), t.GetActiveToken());
    }

    [Fact]
    public void TC3()
    {
    Tokenizer t = new Tokenizer(GetArithmeticGrammar(), "3 + 54 * 4");
    t.GetActiveToken();
    t.GetNextToken();
    t.GetNextToken();
    Assert.Equal(new KeyValuePair<string, string>("MUL", "*"), t.GetNextToken());
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
    Assert.Equal(new KeyValuePair<string, string>("ADD", "+"), t.GetNextToken());
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