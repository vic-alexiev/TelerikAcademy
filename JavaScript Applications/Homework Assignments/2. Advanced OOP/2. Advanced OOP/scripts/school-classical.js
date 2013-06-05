var SchoolObject = Class.create({

    toString: function () {
        var result = "";
        var firstProp = true;
        for (var prop in this) {
            if (!(this[prop] instanceof Function)) {

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

var Person = Class.create(SchoolObject, {
    initialize: function (firstName, lastName, age) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.age = age;
    }
});

var Student = Class.create(Person, {
    initialize: function ($super, firstName, lastName, age, year) {
        $super(firstName, lastName, age);
        this.year = year;
    }
});

var Professor = Class.create(Person, {
    initialize: function ($super, firstName, lastName, age, speciality) {
        $super(firstName, lastName, age);
        this.speciality = speciality;
    }
});

var Course = Class.create(SchoolObject, {
    initialize: function (name, capacity, professor, students) {
        this.name = name;
        this.capacity = capacity;
        this.professor = professor;
        this.students = students;
    }
});

var School = Class.create(SchoolObject, {
    initialize: function (name, town, courses) {
        this.name = name;
        this.town = town;
        this.courses = courses;
    }
});