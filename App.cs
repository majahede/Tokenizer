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

        Tokenizer textTokenizer = new Tokenizer(wordAndDotGrammar, "A cat .");

        Console.WriteLine(textTokenizer.GetActiveToken()); // Expected output: [WORD, A] 
        Console.WriteLine(textTokenizer.GetNextToken()); // Expected output: [WORD, cat]
        Console.WriteLine(textTokenizer.GetNextToken()); // Expected output: [DOT, .]
        Console.WriteLine(textTokenizer.GetPreviousToken()); // Expected output: [WORD, cat]
    }
  }
}

