using System;
using tokenizer;

namespace l1
{
    public class App
    {
       static void Main(string[] args)
    {
        // Grammar wordAndDotGrammar  = new Grammar();
        // RegexRule r = new RegexRule("WORD", "^[\\w|åäöÅÄÖ]+");
        // wordAndDotGrammar.Add(r);
        // r = new RegexRule("DOT", "^\\.");
        // wordAndDotGrammar.Add(r);

        // Tokenizer textTokenizer = new Tokenizer(wordAndDotGrammar, "A cat.");

        // Console.WriteLine(textTokenizer.ActiveToken.Token); // Expected output: [WORD, A]
        // textTokenizer.GetNextToken();
        // Console.WriteLine(textTokenizer.ActiveToken.Token); // Expected output: [WORD, A] 
        // textTokenizer.GetPreviousToken();
        // Console.WriteLine(textTokenizer.ActiveToken.Token); // Expected output: [WORD, A] 
        // textTokenizer.GetPreviousToken();
        // Console.WriteLine(textTokenizer.ActiveToken.Token); // Expected output: [WORD, A]
     //   Console.WriteLine(textTokenizer.ActiveToken.Token); // Expected output: [WORD, A] 
        // Console.WriteLine(textTokenizer.GetNextToken().Token); // Expected output: [WORD, cat]
        // Console.WriteLine(textTokenizer.GetNextToken().Token); // Expected output: [DOT, .]
        // Console.WriteLine(textTokenizer.GetPreviousToken().Token); // Expected output: [WORD, cat]

      //  TokenMatch tokenMatch = new TokenMatch();
      // Console.WriteLine(tokenMatch.Match.Length);
      Grammar arithmeticGrammar  = new Grammar();
      RegexRule r = new RegexRule("NUMBER", "^[0-9]+(\\.([0-9])+)?");
      arithmeticGrammar.Add(r);
      r = new RegexRule("ADD", "^[+]");
      arithmeticGrammar.Add(r);
      r = new RegexRule("MUL", "^[*]");
      arithmeticGrammar.Add(r);

    Tokenizer t = new Tokenizer(arithmeticGrammar, "3 + 54 * 4");
   // t.GetActiveToken(0);
    Console.WriteLine(t.ActiveToken.Token);
    t.GetNextToken();
   // Console.WriteLine(t.ActiveToken.Token);
    t.GetNextToken();
   // Console.WriteLine(t.ActiveToken.Token);
    t.GetNextToken();
    Console.WriteLine(t.ActiveToken.Token);
    }
  }
}

