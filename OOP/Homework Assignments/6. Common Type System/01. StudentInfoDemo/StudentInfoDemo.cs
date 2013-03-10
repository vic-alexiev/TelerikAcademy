using StudentInfo;
using StudentInfo.Enums;
using System;

class StudentInfoDemo
{
    static void Main()
    {
        Student[] students = new Student[]
        {
            new Student(
                "Charles",
                "James",
                "Stuart",
                "721-07-4426",
                "151 South Almaden Boulevard, San Jose, California",
                "020 7290 7701",
                "charles.stuart@gmail.com",
                3,
                Speciality.Architecture,
                University.MassachusettsInstituteOfTechnology,
                School.ArchitectureAndPlanning),

            new Student(
                "John",
                "Sidney",
                "McCain",
                "483-39-9955",
                "500 Oracle Parkway, Redwood Shores, Redwood City, California, United States",
                "089 9212 6511",
                "john.mccain@gmail.com",
                1,
                Speciality.Business,
                University.CarnegieMellon,
                School.Management),
                
            new Student(
                "Lisa",
                "Ann",
                "Murkowski",
                "210-08-9166",
                "1 Dell Way, Round Rock, Texas, United States",
                "012 9858 9900",
                "lisa.murkowski@gmail.com",
                4,
                Speciality.ChemicalEngineering,
                University.Cornell,
                School.Engineering),
                
            new Student(
                "Michael",
                "Farrand",
                "Bennet",
                "309-01-5744",
                "2900 Great Plains Drive South, Fargo, North Dakota",
                "076 9914 1519",
                "michael.bennet@gmail.com",
                2,
                Speciality.History,
                University.JohnsHopkins,
                School.HumanitiesArtsAndSocialSciences),

            new Student(
                "Daniel",
                "Ray",
                "Coats",
                "144-04-9020",
                "8050 Microsoft Way, Charlotte, North Carolina",
                "031 7861 9238",
                "daniel.coats@gmail.com",
                4,
                Speciality.PoliticalScience,
                University.Harvard,
                School.HumanitiesArtsAndSocialSciences),

            new Student(
                "Charles",
                "James",
                "Stuart",
                "138-12-7345",
                "Apple Campus, 1 Infinite Loop, Cupertino, California, U.S.",
                "032 9871 6346",
                "charles.james.stuart@gmail.com",
                4,
                Speciality.OperationsResearch,
                University.UniversityOfChicago,
                School.Science),
        };

        Array.Sort(students);

        foreach (Student student in students)
        {
            Console.WriteLine(student);
        }
    }
}
