## Loops

1. Write a program which prints all the numbers from 1 to `N`.
* Write a program that prints all the numbers from 1 to `N` which are not divisible by both 3 and 7.
* Write a program which reads from the console a sequence of `N` integers and returns the least and the greatest of them.
* Write a program which calculates _N!/K!_ for given `N` and `K` (1 < K < N).
* Write a program which calculates the binomial coefficient _N! / K! * (N-K)!_ for given `N` and `K` (1 < K < N).
* Write a program which, for given two integers `N` and `X`, calculates the sum *S = X<sup>0</sup>/0! + X<sup>1</sup>/1! + X<sup>2</sup>/2! + ... + X<sup>N</sup>/N!* (the exponential function expanded as a Taylor series).
* Write a program which reads an integer `N` and calculates the sum of the first N elements of the Fibonacci sequence: *0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, ...* Each element of the Fibonacci sequence (except for the first two) is a sum of the previous two elements.
* Write a program which calculates the *greatest common divisor* (GCD) of two numbers. Use Euclid's algorithm.
* In combinatorial mathematics, the *Catalan numbers* are calculated by the following formula:

    ![Catalan Number](https://raw.github.com/vic-alexiev/TelerikAcademy/master/C%23%20Fundamentals%20I/Homework%20Assignments/6.%20Loops/09.%20PrintNthCatalanNumber/CatalanNumber.png)
  * Write a program which calculates the N<sup>th</sup> Catalan number by given `N`.
* Write a program which prints all possible cards from a standard 52-card deck (no jokers). Use nested `for` loops and `switch-case` statements.
* Write a program which reads from the console a positive integer `N` (N < 20) and outputs a matrix populated in the following manner:
	* N = 3
<table>
    <tr>
        <td>1</td>
        <td>2</td>
        <td>3</td>
    </tr>
    <tr>
        <td>2</td>
        <td>3</td>
        <td>4</td>
    </tr>
    <tr>
        <td>3</td>
        <td>4</td>
        <td>5</td>
    </tr>
</table>
	* N = 4
<table>
    <tr>
        <td>1</td>
        <td>2</td>
        <td>3</td>
        <td>4</td>
    </tr>
    <tr>
        <td>2</td>
        <td>3</td>
        <td>4</td>
        <td>5</td>
    </tr>
    <tr>
        <td>3</td>
        <td>4</td>
        <td>5</td>
        <td>6</td>
    </tr>
    <tr>
        <td>4</td>
        <td>5</td>
        <td>6</td>
        <td>7</td>
    </tr>
</table>
* \*Write a program which for given `N` finds the number of trailing zeros in N!. Examples:
    * N = 10 -> N! = 36288_00_ -> 2
    * N = 25 -> N! = 15511210043330985984_000000_ -> 6

    Does your program work for N = 50 000? Hint: The trailing zeros in N! are equal to the number of its prime divisors of value 5. Think why!
* \*Write a program which reads a positive integer `N` (N < 20) from console and outputs the numbers 1, ..., N<sup>2</sup> arranged as a spiral.
	* Example: N = 4
<table>
    <tr>
        <td>1</td>
        <td>2</td>
        <td>3</td>
        <td>4</td>
    </tr>
    <tr>
        <td>12</td>
        <td>13</td>
        <td>14</td>
        <td>5</td>
    </tr>
    <tr>
        <td>11</td>
        <td>16</td>
        <td>15</td>
        <td>6</td>
    </tr>
    <tr>
        <td>10</td>
        <td>9</td>
        <td>8</td>
        <td>7</td>
    </tr>
</table>
