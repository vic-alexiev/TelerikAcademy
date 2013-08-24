using StudentSystem.Services.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace StudentSystem.Services.Controllers
{
    public class StudentsController : ApiController
    {
        [HttpGet]
        public IEnumerable<Student> GetAll()
        {
            var students = new List<Student>() {
                
                new Student(){
                    Id = 1,
                    FirstName = "John",
                    LastName = "Muller",
                    Age = 22,
                    Grade = 3,
                    Marks = new List<Mark>()
                    {
                        new Mark()
                        {
                            Subject = "History", 
                            Value = 3
                        },
                        new Mark()
                        {
                            Subject = "Mathematics", 
                            Value = 6
                        },
                        new Mark()
                        {
                            Subject = "Philosophy", 
                            Value = 6
                        },
                        new Mark()
                        {
                            Subject = "Literature",
                            Value = 6
                        },
                        new Mark()
                        {
                            Subject = "Biology",
                            Value = 5
                        },
                        new Mark()
                        {
                            Subject = "Geography",
                            Value = 6
                        },
                    }
                },
                new Student(){
                    Id = 2,
                    FirstName = "Anne",
                    LastName = "Richardson",
                    Age = 20,
                    Grade = 3,
                    Marks = new List<Mark>(){
                        new Mark()
                        {
                            Subject = "History",
                            Value = 3
                        },
                        new Mark()
                        {
                            Subject = "Physics",
                            Value = 6
                        },
                        new Mark()
                        {
                            Subject = "Philosophy",
                            Value = 6
                        },
                        new Mark()
                        {
                            Subject = "Literature",
                            Value = 6
                        },
                        new Mark()
                        {
                            Subject = "Chemistry",
                            Value = 5
                        },
                        new Mark()
                        {
                            Subject = "Mathematics",
                            Value = 6
                        },
                    }
                },
                new Student(){
                    Id = 3,
                    FirstName = "Margaret",
                    LastName = "Peacock",
                    Age = 22,
                    Grade = 3,
                    Marks = new List<Mark>()
                    {
                        new Mark()
                        {
                            Subject = "Biology",
                            Value = 3
                        },
                        new Mark()
                        {
                            Subject = "Mathematics",
                            Value = 6
                        },
                        new Mark()
                        {
                            Subject = "Philosophy",
                            Value = 6
                        },
                        new Mark()
                        {
                            Subject = "Literature",
                            Value = 6
                        },
                        new Mark()
                        {
                            Subject = "English",
                            Value = 5
                        },
                        new Mark()
                        {
                            Subject = "History",
                            Value = 6
                        },
                    }
                },
                new Student(){
                    Id = 4,
                    FirstName = "Michael",
                    LastName = "Suyama",
                    Age = 30,
                    Grade = 4,
                    Marks = new List<Mark>(){
                        new Mark()
                        {
                            Subject = "German",
                            Value = 3
                        },
                        new Mark(){
                            Subject = "Mathematics",
                            Value = 6
                        },
                        new Mark(){
                            Subject = "Philosophy",
                            Value = 6
                        },
                        new Mark(){
                            Subject = "Literature",
                            Value = 6
                        },
                        new Mark(){
                            Subject = "History",
                            Value = 5
                        },
                        new Mark(){
                            Subject = "English",
                            Value = 6
                        },
                    }
                },
                new Student(){
                    Id = 5,
                    FirstName = "Nancy",
                    LastName = "Davolio",
                    Age = 22,
                    Grade = 1,
                    Marks = new List<Mark>(){
                        new Mark()
                        {
                            Subject = "History",
                            Value = 3
                        },
                        new Mark()
                        {
                            Subject = "Mathematics",
                            Value = 6
                        },
                        new Mark()
                        {
                            Subject = "Philosophy",
                            Value = 6
                        },
                        new Mark()
                        {
                            Subject = "Literature",
                            Value = 6
                        },
                        new Mark(){
                            Subject = "Geography",
                            Value = 5
                        },
                        new Mark(){
                            Subject = "Chemistry",
                            Value = 6
                        },
                    }
                },
                new Student(){
                    Id = 6,
                    FirstName = "Thomas",
                    LastName = "Hardy",
                    Age = 22,
                    Grade = 3,
                    Marks = new List<Mark>(){
                        new Mark(){
                            Subject = "History",
                            Value = 3
                        },
                        new Mark(){
                            Subject = "Mathematics",
                            Value = 6
                        },
                        new Mark(){
                            Subject = "Philosophy",
                            Value = 6
                        },
                        new Mark(){
                            Subject = "Literature",
                            Value = 6
                        },
                        new Mark(){
                            Subject = "History",
                            Value = 5
                        },
                        new Mark(){
                            Subject = "Physics",
                            Value = 6
                        },
                    }
                }
            };

            return students;
        }
    }
}
