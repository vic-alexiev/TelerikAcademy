/// <reference path="data-models.js" />

var database = (function () {

    var students = [
        new dataModels.Student(1, "John", "Fuller", 21, 4, [
            new dataModels.Mark("History", 3),
            new dataModels.Mark("Mathematics", 6),
            new dataModels.Mark("Philosophy", 6),
            new dataModels.Mark("Literature", 6),
            new dataModels.Mark("Biology", 5),
            new dataModels.Mark("Geography", 6)]),
        new dataModels.Student(2, "Nancy", "Davolio", 29, 1, [
            new dataModels.Mark("History", 3),
            new dataModels.Mark("Mathematics", 5),
            new dataModels.Mark("Philosophy", 3)]),
        new dataModels.Student(3, "Margaret", "Peacock", 18, 3, [
            new dataModels.Mark("History", 6),
            new dataModels.Mark("Mathematics", 6),
            new dataModels.Mark("Philosophy", 5),
            new dataModels.Mark("Literature", 3)]),
        new dataModels.Student(4, "Anne", "Richardson", 24, 4, [
            new dataModels.Mark("History", 2),
            new dataModels.Mark("Mathematics", 4),
            new dataModels.Mark("Philosophy", 3),
            new dataModels.Mark("Literature", 5),
            new dataModels.Mark("Physics", 3)]),
        new dataModels.Student(5, "Peter", "Buchanan", 38, 2, [
            new dataModels.Mark("History", 6),
            new dataModels.Mark("Mathematics", 6),
            new dataModels.Mark("Philosophy", 5),
            new dataModels.Mark("Literature", 3)]),
        new dataModels.Student(6, "Michael", "Suyama", 27, 4, [
            new dataModels.Mark("Chemistry", 6)])
    ];

    return {
        students: students
    };

})();