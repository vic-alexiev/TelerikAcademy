var dataModels = (function () {
    var Person = Class.create({
        init: function (firstName, lastName, age) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        },

        getFullName: function () {
            return this.firstName + " " + this.lastName;
        }
    });

    var Student = Person.extend({
        init: function (id, firstName, lastName, age, grade, marks) {
            this._super(firstName, lastName, age);
            this.id = id;
            this.grade = grade;
            this.marks = marks;
        }
    });

    var Mark = Class.create({
        init: function (subject, value) {
            this.subject = subject;
            this.value = value;
        }
    });

    return {
        Student: Student,
        Mark: Mark
    };
})();
