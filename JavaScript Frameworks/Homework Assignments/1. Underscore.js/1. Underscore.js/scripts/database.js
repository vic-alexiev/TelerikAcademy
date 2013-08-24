/// <reference path="data-models.js" />

var database = (function () {

    var students = [
        new dataModels.Student("Anne", "Dodsworth", 19, [new dataModels.Mark("History", 4), new dataModels.Mark("Physics", 5), new dataModels.Mark("Biology", 5), new dataModels.Mark("English", 6), new dataModels.Mark("Geography", 6)]),
        new dataModels.Student("Laura", "Callahan", 30, [new dataModels.Mark("History", 6), new dataModels.Mark("Literature", 6), new dataModels.Mark("Maths", 3), new dataModels.Mark("Biology", 5)]),
        new dataModels.Student("Robert", "King", 20, [new dataModels.Mark("Physics", 6), new dataModels.Mark("Geography", 5)]),
        new dataModels.Student("Michael", "Suyama", 35, [new dataModels.Mark("Biology", 6), new dataModels.Mark("Maths", 4), new dataModels.Mark("Chemistry", 5), new dataModels.Mark("Physics", 5)]),
        new dataModels.Student("Steven", "Buchanan", 16, [new dataModels.Mark("Physics", 6), new dataModels.Mark("History", 4), new dataModels.Mark("Maths", 3)]),
        new dataModels.Student("Margaret", "Peacock", 16, [new dataModels.Mark("History", 6), new dataModels.Mark("Literature", 6), new dataModels.Mark("Physics", 4.5)]),
        new dataModels.Student("Janet", "Leverling", 17, [new dataModels.Mark("History", 6), new dataModels.Mark("Chemistry", 6), new dataModels.Mark("Maths", 3)]),
        new dataModels.Student("Andrew", "Fuller", 21, [new dataModels.Mark("Physics", 6), new dataModels.Mark("Literature", 6), new dataModels.Mark("History", 3)]),
        new dataModels.Student("Nancy", "Davolio", 21, [new dataModels.Mark("Geography", 6), new dataModels.Mark("Maths", 4), new dataModels.Mark("Chemistry", 3)]),
        new dataModels.Student("Anne", "Fuller", 16, [new dataModels.Mark("Maths", 6), new dataModels.Mark("History", 6), new dataModels.Mark("Biology", 3)]),
        new dataModels.Student("Robert", "Devereux", 18, [new dataModels.Mark("Physics", 6), new dataModels.Mark("Biology", 6), new dataModels.Mark("Geography", 5)]),
        new dataModels.Student("Michael", "Fuller", 26, [new dataModels.Mark("Chemistry", 6), new dataModels.Mark("Literature", 6), new dataModels.Mark("Maths", 3)]),
        new dataModels.Student("Margaret", "Buchanan", 39, [new dataModels.Mark("History", 6), new dataModels.Mark("Literature", 5), new dataModels.Mark("Maths", 5), new dataModels.Mark("Biology", 3), new dataModels.Mark("Chemistry", 3)]),
        new dataModels.Student("Steven", "Callahan", 28, [new dataModels.Mark("Geography", 6), new dataModels.Mark("History", 5), new dataModels.Mark("Maths", 5), new dataModels.Mark("English", 2), new dataModels.Mark("Biology", 6)])
    ];

    var animals = [
        new dataModels.Animal("Amphibia", "Frog", 4),
        new dataModels.Animal("Amphibia", "Siphonops paulensis", 0),
        new dataModels.Animal("Amphibia", "Diplocaulus", 0),
        new dataModels.Animal("Amphibia", "Northwestern salamander", 4),
        new dataModels.Animal("Diplopoda", "Millipede", 36),
        new dataModels.Animal("Diplopoda", "Scutigera coleoptrata", 30),
        new dataModels.Animal("Diplopoda", "Lithobius forficatus", 300),
        new dataModels.Animal("Diplopoda", "Tachypodoiulus niger", 200),
        new dataModels.Animal("Mammalia", "Goat", 4),
        new dataModels.Animal("Mammalia", "Whale", 0),
        new dataModels.Animal("Mammalia", "Monkey", 2),
        new dataModels.Animal("Mammalia", "Human", 2),
        new dataModels.Animal("Reptilia", "Sand lizard", 4),
        new dataModels.Animal("Reptilia", "Snake", 0),
        new dataModels.Animal("Reptilia", "Crocodile", 4)
    ];

    var books = [
        new dataModels.Book("Leviathan", "Thomas Hobbes"),
        new dataModels.Book("Ethics", "Baruch de Spinoza"),
        new dataModels.Book("Mathematical Principles of Natural Philosophy", "Isaac Newton"),
        new dataModels.Book("The Prince", "Niccolò Machiavelli"),
        new dataModels.Book("Discourses on Livy", "Niccolò Machiavelli"),
        new dataModels.Book("Candide", "Voltaire"),
        new dataModels.Book("Essay on the Customs and the Spirit of the Nations", "Voltaire"),
        new dataModels.Book("The Maid of Orleans", "Voltaire"),
        new dataModels.Book("Zadig", "Voltaire"),
        new dataModels.Book("Treatise on Tolerance", "Voltaire"),
        new dataModels.Book("Dictionnaire philosophique", "Voltaire"),
        new dataModels.Book("War and Peace", "Leo Tolstoy"),
        new dataModels.Book("Anna Karenina", "Leo Tolstoy"),
        new dataModels.Book("Hadji Murat", "Leo Tolstoy"),
        new dataModels.Book("The Cossacks", "Leo Tolstoy")
    ];

    return {
        students: students,
        animals: animals,
        books: books
    };

})();