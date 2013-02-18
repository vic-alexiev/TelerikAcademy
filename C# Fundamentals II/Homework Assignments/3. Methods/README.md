## Methods

1. Write a method that asks the user for their name and prints "Hello, &lt;name&gt;!" (for example "Hello, Peter!"). Write a program to test this method.
* Write a method `GetMax()` which receives two integer parameters and returns the greater of them. Write a program that reads 3 integers from the console and prints the greatest of them. Use the method `GetMax()`.
* Write a method which returns the last digit of a given integer as a word. Examples: 512 -> "two", 1024 -> "four", 12309 -> "nine".
* Write a method which counts the occurrences of a given integer in an array. Write a test program to check if the method works correctly.
* Write a method that checks if the element at a given position in an array of integers is greater than its two neighbors (when such exist).
* Write a method that returns the index of the first element in an array which is greater than its neighbors, or -1 if there’s no such an element.
    * Use the method from the previous exercise.
* Write a method that reverses the digits of a given decimal number. Example: 256 -> 652.
* Write a method that adds two positive integer numbers represented as arrays of their digits (each array element `arr[i]` contains a digit; the last digit is kept in `arr[0]`). Each of the integers that will be added can have up to 10 000 digits.
* Write a method that returns the maximum element in a portion of an array (specified by start and end indexes). Using it, write another method that sorts an array in ascending/descending order.
* Write a program which calculates n! for each n in the range [1...100]. Hint: First implement a method that multiplies an integer by another integer, both represented as arrays of their digits.
* Write a method that adds two polynomials. Each polynomial can be represented as an array of its coefficients (e.g., x<sup>2</sup> + 5 = 1x<sup>2</sup> + 0x + 5 -> { 5, 0, 1 }).
* Extend the previous program so that it supports also subtraction and multiplication of polynomials.
* Write a program that can solve these tasks:
    * Reverses the digits of a number;
    * Calculates the average of a sequence of integers;
    * Solves the linear equation _a * x + b = 0_.

  Create appropriate methods. Provide a simple text-based menu for the user to select the task they want to solve. Validate the input data:
    * The decimal number should be non-negative;
    * The sequence should not be empty;
    * *a* should not be equal to *0*.
* Write methods which find/calculate the minimum, maximum, average, sum and product of a set of integers. Use variable number of arguments.
* \* Modify the previous program and make it work for any number type, not just `int` (e.g., `decimal`, `float`, `byte`, etc.). Use generic methods.
