var dataModels = (function () {

    var Mark = Class.create({
        init: function (subject, value) {
            this.subject = subject;
            this.value = value;
        }
    });

    var Student = Class.create({
        init: function (firstName, lastName, age, marks) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.marks = marks;
        },

        getFullName: function () {
            return this.firstName + " " + this.lastName;
        },

        getAverageMark: function () {
            return _.chain(this.marks).map(function (m) {
                return m.value;
            }).value().reduce(function (a, b) {
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
        },

        toString: function () {
            return "title: " + this.title + " author: " + this.author;
        }
    });

    return {
        Student: Student,
        Mark: Mark,
        Animal: Animal,
        Book: Book
    };

})();