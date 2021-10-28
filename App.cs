using System;
using tokenizer;

namespace l1
{
    public class App
    {
       static void Main(string[] args)
    {
      Grammar wordAndDotGrammar  = new Grammar();

        wordAndDotGrammar.Add("WORD", "^[\\w|åäöÅÄÖ]+");
        wordAndDotGrammar.Add("DOT", "^\\.");

        Tokenizer textTokenizer = new Tokenizer(wordAndDotGrammar, " ");

        Console.WriteLine(textTokenizer.GetActiveToken()); // Expected output: [WORD, A] 
        Console.WriteLine(textTokenizer.GetNextToken()); // Expected output: [WORD, cat]
        Console.WriteLine(textTokenizer.GetNextToken()); // Expected output: [DOT, .]
        Console.WriteLine(textTokenizer.GetPreviousToken()); // Expected output: [WORD, cat]
    }
  }
}

