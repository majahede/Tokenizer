using System;
using tokenizer;

public class App
{
    public static void printToken (Tokenizer t)
    {
        Console.WriteLine(t.ActiveToken.Token + ", " + t.ActiveToken.Match);
    }

    static void Main(string[] args)
    {
        Grammar wordAndDotGrammar  = new Grammar();
        RegexRule r = new RegexRule("WORD", "^[\\w|åäöÅÄÖ]+");
        wordAndDotGrammar.Add(r);
        r = new RegexRule("DOT", "^\\.");
        wordAndDotGrammar.Add(r);

        Tokenizer textTokenizer = new Tokenizer(wordAndDotGrammar, "A cat.");

        printToken(textTokenizer); // Expected output: WORD, A 
        textTokenizer.GetNextToken();
        printToken(textTokenizer); // Expected output: WORD, cat
        textTokenizer.GetNextToken();
        printToken(textTokenizer); // Expected output: DOT, .
        textTokenizer.GetPreviousToken();
        printToken(textTokenizer); // Expected output: WORD, cat
    }
}


