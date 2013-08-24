using Students.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Students.Services.Controllers
{
    public class StudentsController : ApiController
    {
        private List<Student> students;

        public StudentsController()
        {
            students = new List<Student>() 
            { 
                new Student()
                {
                    Id = 1,
                    Name = "John Muller",
                    Grade = 3,
                    Marks = new List<Mark>()
                    {
                        new Mark()
                        {
                            Subject = "History",
                            Score = 3
                        },
                        new Mark()
                        {
                            Subject = "Mathematics",
                            Score = 6
                        },
                        new Mark()
                        {
                            Subject = "Philosophy",
                            Score = 6
                        },
                        new Mark()
                        {
                            Subject = "Literature",
                            Score = 6
                        },
                        new Mark()
                        {
                            Subject = "Biology",
                            Score = 5
                        },
                        new Mark()
                        {
                            Subject = "Geography",
                            Score = 6
                        }
                    }
                },
                new Student()
                {
                    Id = 2,
                    Name = "Anne Dodsworth",
                    Grade = 4,
                    Marks = new List<Mark>()
                    {
                        new Mark()
                        {
                            Subject = "History",
                            Score = 6
                        },
                        new Mark()
                        {
                            Subject = "Physics",
                            Score = 5
                        },
                        new Mark()
                        {
                            Subject = "Literature",
                            Score = 6
                        },
                        new Mark()
                        {
                            Subject = "Philosophy",
                            Score = 6
                        },
                        new Mark()
                        {
                            Subject = "Chemistry",
                            Score = 5
                        },
                        new Mark()
                        {
                            Subject = "Mathematics",
                            Score = 6
                        }
                    }
                },
                new Student()
                {
                    Id = 3,
                    Name = "Janet Leverling",
                    Grade = 5,
                    Marks = new List<Mark>()
                    {
                        new Mark()
                        {
                            Subject = "Physics",
                            Score = 6
                        },
                        new Mark()
                        {
                            Subject = "Mathematics",
                            Score = 5
                        },
                        new Mark()
                        {
                            Subject = "Philosophy",
                            Score = 4
                        },
                        new Mark()
                        {
                            Subject = "Geography",
                            Score = 6
                        },
                        new Mark()
                        {
                            Subject = "Biology",
                            Score = 6
                        },
                        new Mark()
                        {
                            Subject = "History",
                            Score = 6
                        }
                    }
                },
                new Student()
                {
                    Id = 4,
                    Name = "Robert King",
                    Grade = 4,
                    Marks = new List<Mark>()
                    {
                        new Mark()
                        {
                            Subject = "History",
                            Score = 3
                        },
                        new Mark()
                        {
                            Subject = "Mathematics",
                            Score = 6
                        },
                        new Mark()
                        {
                            Subject = "Philosophy",
                            Score = 6
                        },
                        new Mark()
                        {
                            Subject = "Literature",
                            Score = 6
                        },
                        new Mark()
                        {
                            Subject = "Physics",
                            Score = 5
                        },
                        new Mark()
                        {
                            Subject = "Chemistry",
                            Score = 6
                        }
                    }
                },
                new Student()
                {
                    Id = 5,
                    Name = "Michael Buchanan",
                    Grade = 3,
                    Marks = new List<Mark>()
                    {
                        new Mark()
                        {
                            Subject = "Geography",
                            Score = 5
                        },
                        new Mark()
                        {
                            Subject = "Mathematics",
                            Score = 6
                        },
                        new Mark()
                        {
                            Subject = "Philosophy",
                            Score = 5
                        },
                        new Mark()
                        {
                            Subject = "Literature",
                            Score = 6
                        },
                        new Mark()
                        {
                            Subject = "History",
                            Score = 6
                        },
                        new Mark()
                        {
                            Subject = "Chemistry",
                            Score = 3
                        }
                    }
                },
                new Student()
                {
                    Id = 6,
                    Name = "Thomas Hardy",
                    Grade = 3,
                    Marks = new List<Mark>()
                    {
                        new Mark()
                        {
                            Subject = "Physics",
                            Score = 6
                        },
                        new Mark()
                        {
                            Subject = "English",
                            Score = 6
                        },
                        new Mark()
                        {
                            Subject = "Philosophy",
                            Score = 6
                        },
                        new Mark()
                        {
                            Subject = "Mathematics",
                            Score = 6
                        },
                        new Mark()
                        {
                            Subject = "History",
                            Score = 5
                        },
                        new Mark()
                        {
                            Subject = "Biology",
                            Score = 6
                        }
                    }
                }
            };
        }

        [HttpGet]
        [ActionName("basic")]
        public IEnumerable<Student> GetAll()
        {
            var result =
                from student in students
                select new Student
                {
                    Id = student.Id,
                    Name = student.Name,
                    Grade = student.Grade
                };

            return result;
        }

        [HttpGet]
        [ActionName("detailed")]
        public IEnumerable<Student> GetAllDetailed()
        {
            return students;
        }

        [HttpGet]
        [ActionName("marks")]
        public Student GetMarks(int studentId)
        {
            var student = students.FirstOrDefault(s => s.Id == studentId);

            if (student == null)
            {
                throw new ArgumentException("Invalid student Id.");
            }

            return student;
        }
    }
}
