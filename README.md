# Tokenizer

## Classes

### `Grammar`

The Grammar constructor creates a new Grammar.

```c#
   Grammar arithmeticGrammar  = new Grammar();
```

### `Tokenizer`

The Tokenizer constructor creates a new Tokenizer and takes a grammar and a string as arguments.

```c#
   Tokenizer mathTokenizer = new Tokenizer(arithmeticGrammar, "1 + 6");
```

## Methods

### `Add(string token, string regex)`
A method that when called will add a token with a matching regex to a dictionary. Always add '^' at the beginning of the regexpattern to make sure it matches the beginning of a string.

```c#
   arithemticGrammar.Add("NUMBER", "^[0-9]+(\\.([0-9])+)?");
```

### `GetActiveToken()`
A method that when called will get the active token of a string.

```c#
mathTokenizer.GetActiveToken();
```

### `GetNextToken()`
A method that when called will get the next token of a string.

```c#
mathTokenizer.GetNextToken();
```

### `GetPreviousToken()`
A method that when called will get the previous token of a string.

```c#
mathTokenizer.GetPreviousToken();
```


## Example
```c#
  Grammar wordAndDotGrammar  = new Grammar();

  wordAndDotGrammar.Add("WORD", "^[\\w|åäöÅÄÖ]+");
  wordAndDotGrammar.Add("DOT", "^\\.");

  Tokenizer textTokenizer = new Tokenizer(wordAndDotGrammar, "A cat.");

  Console.WriteLine(textTokenizer.GetActiveToken()); // Expected output: [WORD, A] 
  Console.WriteLine(textTokenizer.GetNextToken()); // Expected output: [WORD, cat]
  Console.WriteLine(textTokenizer.GetNextToken()); // Expected output: [DOT, .]
  Console.WriteLine(textTokenizer.GetPreviousToken()); // Expected output: [WORD, cat]
```



