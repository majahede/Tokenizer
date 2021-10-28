// using System;
// using System.Collections.Generic;
// using Xunit;
// using tokenizer;

// public class WordAndDotGrammarTest
// {
//     public Grammar GetWordAndDotGrammar() {
//       Grammar wordAndDotGrammar  = new Grammar();
//       wordAndDotGrammar.Add("WORD", "^[\\w|åäöÅÄÖ]+");
//       wordAndDotGrammar.Add("DOT", "^\\.");
//       return wordAndDotGrammar;
//     }

//     [Fact]
//     public void TC1()
//     {
//       Tokenizer t = new Tokenizer(GetWordAndDotGrammar(), "a");
//       Assert.Equal(new KeyValuePair<string, string>("WORD", "a"), t.GetActiveToken());
//     }

//     [Fact]
//     public void TC2()
//     {
//       Tokenizer t = new Tokenizer(GetWordAndDotGrammar(), "a aa");
//       t.GetActiveToken();
//       Assert.Equal(new KeyValuePair<string, string>("WORD", "aa"), t.GetNextToken());
//     }

//     [Fact]
//     public void TC3()
//     {
//       Tokenizer t = new Tokenizer(GetWordAndDotGrammar(), "a.b");
//       t.GetActiveToken();
//       Assert.Equal(new KeyValuePair<string, string>("DOT", "."), t.GetNextToken());
//     }

//     [Fact]
//     public void TC4()
//     {
//      Tokenizer t = new Tokenizer(GetWordAndDotGrammar(), "a.b");
//       t.GetActiveToken();
//       t.GetNextToken();
//       Assert.Equal(new KeyValuePair<string, string>("WORD", "b"), t.GetNextToken());
//     }

//     [Fact]
//     public void TC5()
//     {
//      Tokenizer t = new Tokenizer(GetWordAndDotGrammar(), "aa. b");
//       t.GetActiveToken();
//       t.GetNextToken();
//       Assert.Equal(new KeyValuePair<string, string>("WORD", "b"), t.GetNextToken());
//     }

//     [Fact]
//     public void TC6()
//     {
//      Tokenizer t = new Tokenizer(GetWordAndDotGrammar(), "a .b");
//       t.GetActiveToken();
//       t.GetNextToken();
//       t.GetNextToken();
//       Assert.Equal(new KeyValuePair<string, string>("DOT", "."), t.GetPreviousToken());
//     }

//     [Fact]
//     public void TC7()
//     {
//      Tokenizer t = new Tokenizer(GetWordAndDotGrammar(), "");
//       Assert.Equal(new KeyValuePair<string, string>("END", ""), t.GetActiveToken());
//     }

//     [Fact]
//     public void TC8()
//     {
//      Tokenizer t = new Tokenizer(GetWordAndDotGrammar(), " ");
//      Assert.Equal(new KeyValuePair<string, string>("END", ""), t.GetActiveToken());
//     }

//     [Fact]
//     public void TC9()
//     {
//     Tokenizer t = new Tokenizer(GetWordAndDotGrammar(), "a");
//      t.GetActiveToken();
//      Assert.Equal(new KeyValuePair<string, string>("END", ""), t.GetNextToken());
//     }

//     [Fact]
//     public void TC10()
//     {
//      Tokenizer t = new Tokenizer(GetWordAndDotGrammar(), "a");
//      t.GetActiveToken();
//      Assert.Throws<IndexOutOfRangeException>(() => t.GetPreviousToken());
//     }

//     [Fact]
//     public void TC11()
//     {
//     Tokenizer t = new Tokenizer(GetWordAndDotGrammar(), "!");
//     Assert.Throws<Exception>(() => t.GetActiveToken());
//     }

//     [Fact]
//     public void TC12()
//     {
//     Tokenizer t = new Tokenizer(GetWordAndDotGrammar(), "aa a");
//     t.GetActiveToken();
//     t.GetNextToken();
//     t.GetNextToken();
//     Assert.Throws<IndexOutOfRangeException>(() => t.GetNextToken());
//     }

//     [Fact]
//     public void TC13()
//     {
//     Tokenizer t = new Tokenizer(GetWordAndDotGrammar(), "aa a");
//     t.GetActiveToken();
//     Assert.Throws<IndexOutOfRangeException>(() => t.GetPreviousToken());
//     }
// }