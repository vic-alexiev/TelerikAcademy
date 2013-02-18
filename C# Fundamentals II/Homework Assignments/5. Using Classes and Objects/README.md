## Using Classes and Objects

1. Write a program that reads a year (an integer between 1 and 9999) from the console and checks whether it is a leap one. Use `DateTime`.
* Write a program that generates and prints to the console 10 random values in the range [100...200].
* Write a program that prints to the console the current day of the week. Use `System.DateTime`.
* Write methods that calculate the surface of a triangle by given:
    * Side and its altitude;
    * Three sides;
    * Two sides and an angle between them.
* Write a method that calculates the number of workdays between today and a given date, passed as parameter. Consider that workdays are all days from Monday to Friday except a fixed list of public holidays specified preliminary as an array.
* You are given a sequence of positive integers separated by spaces. Write a method that reads these values (a string) from the console and calculates their sum. Example: input string = "43 68 9 23 318" -> result = 461.
* \* Write a program that calculates the value of a given arithmetic expression. The expression can contain the following elements only:
    * Real numbers, e.g. 5, 18.33, 3.14159, 12.6;
    * Arithmetic operators: +, -, *, / (standard priorities);
    * Mathematical functions: ln(x), sqrt(x), pow(x,y);
    * Brackets (for changing the default priorities);

  Examples:
  * (3+5.3) * 2.7 - ln(22) / pow(2.2, -1.7) -> ~ 10.6
  * pow(2, 3.14) * (3 - (3 * sqrt(2) - 3.2) + 1.5*0.3) -> ~ 21.22
    
  Hint: Use the *shunting-yard algorithm* to convert the expression into *Reverse Polish notation (RPN)*.
