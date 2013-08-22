var Student = Class.create({
    init: function (firstName, lastName, age, marks) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
        this.marks = marks;
        return this;
    },

    getFullName: function () {
        return this.firstName + " " + this.lastName;
    },

    getAverageMark: function () {
        return _.reduce(this.marks, function (a, b) {
            return a + b;
        }) / this.marks.length;
    },

    toString: function () {
        return this.firstName + " " + this.lastName +
            ", age: " + this.age + ", avg mark: " + this.getAverageMark().toFixed(2);
    }
});

var Animal = Class.create({
    init: function (animalClass, species, legsCount) {
        this.animalClass = animalClass;
        this.species = species;
        this.legsCount = legsCount;
        return this;
    },

    toString: function () {
        return "class: " + this.animalClass +
            " species: " + this.species;
    }
});

var Book = Class.create({
    init: function (title, author) {
        this.title = title;
        this.author = author;
        return this;
    },

    toString: function () {
        return "title: " + this.title + " author: " + this.author;
    }
});

var students = [
    new Student("Anne", "Dodsworth", 19, [4, 5, 5, 6, 6]),
    new Student("Laura", "Callahan", 30, [6, 6, 3, 5]),
    new Student("Robert", "King", 20, [6, 5]),
    new Student("Michael", "Suyama", 35, [6, 4, 5, 5]),
    new Student("Steven", "Buchanan", 16, [6, 4, 3]),
    new Student("Margaret", "Peacock", 16, [6, 6, 4.5]),
    new Student("Janet", "Leverling", 17, [6, 6, 3]),
    new Student("Andrew", "Fuller", 21, [6, 6, 3]),
    new Student("Nancy", "Davolio", 21, [6, 4, 3]),
    new Student("Anne", "Fuller", 16, [6, 6, 3]),
    new Student("Robert", "King", 18, [6, 6, 5]),
    new Student("Michael", "Fuller", 26, [6, 6, 3]),
    new Student("Margaret", "Buchanan", 39, [6, 5, 5, 3, 3]),
    new Student("Steven", "Callahan", 28, [6, 5, 5, 2, 6]),
];

var animals = [
    new Animal("Amphibia", "Frog", 4),
    new Animal("Amphibia", "Siphonops paulensis", 0),
	new Animal("Amphibia", "Diplocaulus", 0),
	new Animal("Amphibia", "Northwestern salamander", 4),
	new Animal("Diplopoda", "Millipede", 36),
	new Animal("Diplopoda", "Scutigera coleoptrata", 30),
	new Animal("Diplopoda", "Lithobius forficatus", 300),
	new Animal("Diplopoda", "Tachypodoiulus niger", 200),
	new Animal("Mammalia", "Goat", 4),
	new Animal("Mammalia", "Whale", 0),
	new Animal("Mammalia", "Monkey", 2),
	new Animal("Mammalia", "Human", 2),
	new Animal("Reptilia", "Sand lizard", 4),
	new Animal("Reptilia", "Snake", 0),
	new Animal("Reptilia", "Crocodile", 4)
];

var books = [
    new Book("Leviathan", "Thomas Hobbes"),
    new Book("Ethics", "Baruch de Spinoza"),
	new Book("Mathematical Principles of Natural Philosophy", "Isaac Newton"),
	new Book("The Prince", "Niccolò Machiavelli"),
	new Book("Discourses on Livy", "Niccolò Machiavelli"),
	new Book("Candide", "Voltaire"),
	new Book("Essay on the Customs and the Spirit of the Nations", "Voltaire"),
	new Book("The Maid of Orleans", "Voltaire"),
	new Book("Zadig", "Voltaire"),
	new Book("Treatise on Tolerance", "Voltaire"),
	new Book("Dictionnaire philosophique", "Voltaire"),
	new Book("War and Peace", "Leo Tolstoy"),
	new Book("Anna Karenina", "Leo Tolstoy"),
	new Book("Hadji Murat", "Leo Tolstoy"),
	new Book("The Cossacks", "Leo Tolstoy")
];