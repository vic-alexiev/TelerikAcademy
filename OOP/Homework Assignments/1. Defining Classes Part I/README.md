## Defining Classes Part I

1. Define a class that holds information about a mobile phone device: brand, manufacturer, price, owner, battery characteristics (brand, stand-by time and talk time) and display characteristics (size and number of colors). Define 3 separate classes (class `Gsm` holding instances of the classes `Battery` and `Display`).
* Define several constructors for the defined classes that take different sets of arguments (the full information for the class or part of it). Assume that `brand` and `manufacturer` are mandatory (the rest are optional). All unknown data fill with null.
* Add an enumeration `BatteryType` (Li-Ion, NiMH, NiCd, ...) and use it as a new field for the batteries.
* Add a method in the `Gsm` class which displays all information about a mobile phone. Override `ToString()`.
* Use properties to encapsulate the data fields inside the `Gsm`, `Battery` and `Display` classes. Make sure all fields hold correct data.
* Add a static field and a property `IPhone4S` in the `Gsm` class which holds the information about iPhone 4S.
* Write a class `GsmTest` to test the `Gsm` class:
  * Create an array of several instances of the `Gsm` class.
	* Display the information about the `Gsm` objects in the array.
	* Display the information about the static property `IPhone4S`.
* Create a class `Call` which holds a call made with the mobile phone. It should contain date, time, dialled phone number and duration (in seconds).
* Add a property `CallHistory` in the `Gsm` class which holds a list of the calls made with the phone. Use the generic class `List<Call>`.
* Add methods in the `Gsm` class which add and delete calls from the call history. Add a method that clears the call history.
* Add a method that calculates the total price of the calls in the call history. Assume the price per minute is fixed and it is provided as a parameter.
* Write a class `GsmCallHistoryTest` which tests the call history functionality of the `Gsm` class.
	* Create an instance of the `Gsm` class.
	* Add some calls.
	* Display the information about the calls.
	* Assuming that the price per minute is *0.37*, calculate and print the total price of the calls in the history.
	* Remove the longest call from the history and calculate the total price again.
	* Clear the call history and print it.
