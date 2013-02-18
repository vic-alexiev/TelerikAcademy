## Strings and Text Processing

1. Describe strings in C#. What is typical of the `string` data type? Describe the most important methods of the `String` class.
* Write a program that reads a string, reverses it and prints the result to the console.
    * Example: `"sample"` -> `"elpmas"`.
* Write a program which checks if the brackets in a given expression are put correctly.
    * Example of a correct expression: `"((a+b)/5-d)"`.
    * Example of an incorrect expression: `")(a+b))"`.
* Write a program that finds how many times a substring occurs in a given text (ignore case). Example:
    * The target substring is `"in"`.
    * The text is as follows: `"We are living in a yellow submarine. We don't have anything else.`<br/>
      `Inside the submarine it is very tight. So we are drinking all day long. We will move out of it in 5 days."`
    * The result is `9`.
* You are given a text. Write a program that changes the text in all regions surrounded by the tags `<upcase>` and `</upcase>` to uppercase. The tags cannot be nested.
    *  Example: `"We are living in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else."`
    * The expected result: `"We are living in a YELLOW SUBMARINE. We don't have ANYTHING else."`
* Write a program that reads from the console a string with maximum length of 20 characters. If the length is less than 20, the rest of the characters should be filled with an asterisk (`'*'`). Print the result string to the console.
* Write a program that encodes and decodes a string using a given encryption key (cipher). The key is a sequence of characters. The encoding/decoding is done by performing XOR (exclusive or) on each character in the string and its corresponding character in the key. When the last key character is reached, then start from the beginning of the key.
* Write a program that extracts from a given text all sentences containing a given word. Assume that the sentences are separated by a fullstop (`"."`) and the words – by non-letter symbols.
    * Example: The word is `"in"`.
    * The text is: `"We are living in a yellow submarine. We don't have anything else.`<br/>
      `Inside the submarine it is very tight. So we are drinking all day long. We will move out of it in 5 days."`
    * The expected result is: `"We are living in a yellow submarine. We will move out of it in 5 days."`
* You are given a string containing a list of forbidden words and a text containing some of these words. Write a program that replaces each character of the forbidden words with an asterisk.
    * Example: `"Microsoft announced its next generation PHP compiler today.`<br/>
      `It is based on .NET Framework 4 and is implemented as a dynamic language in CLR."`
    * Words: `"PHP, CLR, Microsoft"`
    * The expected result: `"********* announced its next generation *** compiler today.`<br/>
      `It is based on .NET Framework 4.0 and is implemented as a dynamic language in ***."`
* Write a program that converts a string into a sequence of C# Unicode character literals. Use format strings.
   * Sample input: `"Hi!"`.
   * Expected output: `"\u0048\u0069\u0021"`.
* Write a program that reads a number and prints it in decimal and hexadecimal format, as percentage and in scientific notation. The output should be aligned right in a space of 15 characters.
* Write a program that parses a URL address given in the format: `[protocol]://[server]/[resource]`. Example:
    * `URL = "http://www.devbg.org/forum/index.php"`
    * `[protocol] = "http"`
    * `[server] = "www.devbg.org"`
    * `[resource] = "/forum/index.php"`
* Write a program that reverses the words in a given sentence keeping the original punctuation. Example:
    * `"C# is not C++, not PHP and not Delphi!"`
    * `"Delphi not and PHP, not C++ not is C#!"`
* A dictionary is stored as a sequence of text lines containing words and their explanations. Write a program that reads a word from the console and translates it by using the dictionary. Sample dictionary:
    * `".NET" – "platform for applications from Microsoft"`
    * `"CLR" – "managed execution environment for .NET"`
    * `"namespace" – "hierarchical organization of classes"`
* Write a program that replaces in an HTML document given as string all the tags `<a href="...">...</a>` with the tags `[URL=...]...[/URL]`.
    * Sample HTML fragment: `"<p>Please visit <a href="http://academy.telerik. com">our site</a> to choose`<br/> 
      `a training course. Also visit <a href="forums.academy.telerik.com">our forum</a> to discuss the courses.</p>"`
    * Sample ouput: `"<p>Please visit [URL=http://academy.telerik. com]our site[/URL] to choose`<br/>
      `a training course. Also visit [URL=forums.academy.telerik.com]our forum[/URL] to discuss the courses.</p>"`
* Write a program that reads two dates in the format: `day.month.year` and calculates the number of days between them. Example:
    * `"Enter the first date: 27.02.2006"`
    * `"Enter the second date: 3.03.2006"`
    * `"Distance: 4 days"`
* Write a program that reads a date and time given in the format `day.month.year hour:minute:second` and prints the date and time after 6 hours and 30 minutes (in the same format) along with the day of week in Bulgarian.
* Write a program that extracts all email addresses from a given text. All substrings that match the format `<identifier>@<host>...<domain>` should be recognized as emails.
* Write a program that extracts from a given text all dates that match the format `DD.MM.YYYY`. Display them in the standard date format for Canada.
* Write a program that extracts from a given text all palindromes, e.g. `"ABBA"`, `"lamal"`, `"exe"`.
* Write a program that reads a string from the console and prints how many times each letter occurs in the string.
* Write a program that reads a string from the console and prints how many times each word occurs in the string.
* Write a program that reads a string from the console and replaces each sequence of identical letters with a single letter. 
	Example: `"aaaaabbbbbcdddeeeedssaa"` -> `"abcdedsa"`.
* Write a program that reads a list of words, separated with spaces and prints the list in alphabetical order.
* Write a program that extracts from a given HTML file its title (if available), and its body contents with the HTML tags removed. Example:

   ```html
   <html>
     <head><title>News</title></head>
     <body>
       <p><a href="http://academy.telerik.com">Telerik Academy</a> aims to provide free real-world practical 
       training for young people who want to turn into skillful .NET software engineers.</p>
     </body>
   </html>
   ```
  Result: `"News"`,<br/>
  `"Telerik Academy aims to provide free real-world practical training for young people`<br/>
  `who want to turn into skillful .NET software engineers."`
