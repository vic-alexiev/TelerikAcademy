## Exception Handling

1. Write a program that reads an integer and calculates and prints its square root. If the number is invalid or negative, print `Invalid number`. In all cases print `Goodbye` in the end. Use `try-catch-finally`.
* Write a method `ReadNumber(int start, int end)` that reads an integer in a given range [start...end]. If an invalid number or not-a-number (NaN) is entered, the method should throw an exception. Using this method, write a program that enters 10 numbers: *a<sub>1</sub>, a<sub>2</sub>, ..., a<sub>10</sub>*, such that *1 < a<sub>1</sub> < a<sub>2</sub> < ... < a<sub>10</sub> < 100*.
* Write a program that enters a file path (e.g. `C:\WINDOWS\win.ini`), reads its contents and prints it to the console. Find in MSDN how to use `System.IO.File.ReadAllText()`. Make sure the program catches all possible exceptions and prints user-friendly error messages.
* Write a program that downloads a file via the Internet (e.g. `http://www.devbg.org/img/Logo-BASD.jpg`) and stores it in the current directory. Make sure the program catches all exceptions and frees all used resources using a finally block.
