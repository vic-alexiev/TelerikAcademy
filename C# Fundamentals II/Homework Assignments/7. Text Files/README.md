## Text Files

1. Write a program that reads a text file and prints the odd lines to the console.
* Write a program that concatenates two text files into another text file.
* Write a program that reads a text file and inserts line numbers in front of each line. The result should be written to another text file.
* Write a program that compares two text files line by line and prints the number of lines which are identical and the number of lines which are different. You can assume that the files have the same number of lines.
* Write a program that reads a text file containing a square matrix of numbers and finds a 2x2-platform whose elements have a maximum sum. The first line in the input file contains the size of the matrix *N*. Each of the next *N* lines contain *N* numbers separated by spaces. The output should be a single number in a separate text file. Example (N = 4):
  <table border=0>
      <tr>
          <td>2</td>
          <td>3</td>
          <td>3</td>
          <td>4</td>
      </tr>
      <tr>
          <td>0</td>
          <td>2</td>
          <td>3</td>
          <td>4</td>
      </tr>
      <tr>
          <td><strong>3</strong></td>
          <td><strong>7</strong></td>
          <td>1</td>
          <td>2</td>
      </tr>
      <tr>
          <td><strong>4</strong></td>
          <td><strong>3</strong></td>
          <td>3</td>
          <td>2</td>
      </tr>
  </table>
  -> 17
* Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file. Example:
  <table>
    <tr>
        <td>Ivan</td>
        <td>George</td>
    </tr>
    <tr>
        <td>Peter</td>
        <td>Ivan</td>
    </tr>
    <tr>
        <td>Maria</td>
        <td>Maria</td>
    </tr>
    <tr>
        <td>George</td>
        <td>Peter</td>
    </tr>
  </table>
* Write a program that replaces all occurrences of the substring "start" with the substring "finish" in a text file. Make sure it works with large files (e.g. 100 MB).
* Modify the previous program to replace only whole words.
* Write a program that deletes the odd lines in a given text file. The result should be in the same file.
* Write a program that extracts from given XML file all the text without the tags. Example:
    
    ```xml
    <?xml version="1.0"?>
	<student>
	  <name>Pesho</name>
	  <age>21</age>
	  <interests count="3">
		<interest>Games</interest>
		<interest>C#</interest>
		<interest>Java</interest>
	  </interests>
	</student>
    ```
* Write a program that deletes from a text file all words having the prefix "test". Words contain only alphanumeric characters - *0...9, a...z, A...Z, _*.
* Write a program that removes from a text file all words listed in another text file. Handle all possible exceptions in your methods.
* Write a program that reads a list of words from a file `words.txt` and finds how many times each word occurs in another file `test.txt`. The result should be written in the file `result.txt` and the words should be sorted by their occurrences in descending order. Handle all possible exceptions in your methods.
