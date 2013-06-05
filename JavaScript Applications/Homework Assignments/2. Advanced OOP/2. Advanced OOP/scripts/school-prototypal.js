var SchoolObject = Object.subClass({

    toString: function () {
        var result = "";
        var firstProp = true;
        for (var prop in this) {
            if (!(this[prop] instanceof Function) && prop !== "_super") {

                if (!firstProp) {
                    result += ", ";
                } else {
                    firstProp = false;
                }

                if (!(this[prop] instanceof Array)) {
                    result += (prop + ": " + this[prop]);

                } else {

                    if (this[prop].length > 0) {
                        result += (prop + ": [{" + this[prop][0] + "}");
                        for (var i = 1; i < this[prop].length; i++) {
                            result += (", {" + this[prop][i] + "}");
                        }

                        result += "]";
                    }
                }
            }
        }

        return result;
    }
});

var Person = SchoolObject.subClass({
    init: function (firstName, lastName, age) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }
});

var Student = Person.subClass({
    init: function (firstName, lastName, age, year) {
        this._super(firstName, lastName, age);
        this.year = year;
    }
});

var Professor = Person.subClass({
    init: function (firstName, lastName, age, speciality) {
        this._super(firstName, lastName, age);
        this.speciality = speciality;
    }
});

var Course = SchoolObject.subClass({
    init: function (name, capacity, professor, students) {
        this.name = name;
        this.capacity = capacity;
        this.professor = professor;
        this.students = students;
    }
});

var School = SchoolObject.subClass({
    init: function (name, town, courses) {
        this.name = name;
        this.town = town;
        this.courses = courses;
    }
});