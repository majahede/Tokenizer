# Tokenizer

## Example
```c#
  Grammar wordAndDotGrammar  = new Grammar();
  RegexRule r = new RegexRule("WORD", "^[\\w|åäöÅÄÖ]+");
  wordAndDotGrammar.Add(r);
  r = new RegexRule("DOT", "^\\.");
  wordAndDotGrammar.Add(r);

  Tokenizer textTokenizer = new Tokenizer(wordAndDotGrammar, "A cat.");

  Console.WriteLine(t.ActiveToken.Token + ", " + t.ActiveToken.Match); // Expected output: WORD, A 
  textTokenizer.GetNextToken();
  Console.WriteLine(t.ActiveToken.Token + ", " + t.ActiveToken.Match); // Expected output: WORD, cat
  textTokenizer.GetNextToken();
  Console.WriteLine(t.ActiveToken.Token + ", " + t.ActiveToken.Match); // Expected output: DOT, .
  textTokenizer.GetPreviousToken();
  Console.WriteLine(t.ActiveToken.Token + ", " + t.ActiveToken.Match); // Expected output: WORD, cat
```



