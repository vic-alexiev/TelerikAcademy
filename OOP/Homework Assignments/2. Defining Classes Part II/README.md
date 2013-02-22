## Defining Classes Part II

1. Create a structure `Point3D` which holds the coordinates (X, Y, Z) of a point in the Euclidean 3D space. Implement `ToString()` so that you can print a 3D point.
* Add a private static read-only field which holds the origin of the coordinate system – the point O(0, 0, 0). Add a static property to access the point O.
* Write a static class with a static method which calculates the distance between two points in the 3D space.
* Create a class `Path` that holds a sequence of points in the 3D space. Create a static class `PathStorage` with static methods for saving and loading paths from a text file. Use a file format of your choice.
* Write a generic class `GenericList<T>` that keeps a list of elements of some type `T`. Keep the elements of the list in an array which is passed as a parameter in the class constructor. Implement methods for adding an element, accessing an element by index, removing an element by index, inserting an element at a specified position, clearing the list, finding an element by its value and the method `ToString()`. Check all input parameters to avoid accessing non-existent elements.
* Implement _autogrow_ functionality: when the internal array is full, create a new array with a doubled size and move the elements there.
* Create generic methods `Min<T>()` and `Max<T>()` to find the minimum and maximum element in the `GenericList<T>`. You may need to add generic constraints for the type `T`.
* Define a class `Matrix<T>` which holds a matrix of numbers (`int`, `float`, `decimal`, etc.).
* Implement an indexer `public T this[int row, int col]` to access the matrix elements.
* Implement the operators `+` and `-` (addition and subtraction of matrices of the same size) and `*` for matrix multiplication. Throw an exception when the operation cannot be performed. Implement the `true` operator (check for non-zero elements).
* Create a `Version` attribute that can be applied to structures, classes, interfaces, enumerations and methods and holds a version in the format _major.minor_ (e.g. _2.11_). Apply the `Version` attribute to a sample class and display its version at runtime.
