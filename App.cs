using System;
using tokenizer;

namespace l1
{
    public class App
    {
       static void Main(string[] args)
    {
        Grammar wordAndDotGrammar  = new Grammar();
        RegexRule r = new RegexRule("WORD", "^[\\w|åäöÅÄÖ]+");
        wordAndDotGrammar.Add(r);
        r = new RegexRule("DOT", "^\\.");
        wordAndDotGrammar.Add(r);

        Tokenizer textTokenizer = new Tokenizer(wordAndDotGrammar, "hej ");

        Console.WriteLine(textTokenizer.GetActiveToken().Token); // Expected output: [WORD, A] 
        Console.WriteLine(textTokenizer.GetNextToken().Token); // Expected output: [WORD, cat]
        Console.WriteLine(textTokenizer.GetNextToken().Token); // Expected output: [DOT, .]
        Console.WriteLine(textTokenizer.GetPreviousToken().Token); // Expected output: [WORD, cat]

      //  TokenMatch tokenMatch = new TokenMatch();
      // Console.WriteLine(tokenMatch.Match.Length);
    }
  }
}

