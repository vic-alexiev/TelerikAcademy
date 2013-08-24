/// <reference path="../libs/class.js" />

define(["../libs/class"], function (Class) {

    var dataModels = (function () {
        var Person = Class.create({
            init: function (name) {
                this.name = name;
            }
        });

        var Mark = Class.create({
            init: function (subject, score) {
                this.subject = subject;
                this.score = score;
            }
        });

        var Student = Person.extend({
            init: function (id, name, grade, marks) {
                this._super(name);
                this.grade = grade;
                this.marks = marks;
                this.id = id;
            }
        });

        return {
            Student: Student,
            Mark: Mark
        };
    })();

    return dataModels;
});
