using StudentInfo.Enums;
using System;

namespace StudentInfo
{
    public class Student : ICloneable, IComparable<Student>
    {
        #region Private Fields

        private string firstName;
        private string middleName;
        private string lastName;
        private string ssn;
        private string permanentAddress;
        private string mobilePhone;
        private string email;
        private int year;
        private Speciality speciality;
        private School school;
        private University university;

        #endregion

        #region Properties

        public string FirstName
        {
            get
            {
                return firstName;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("First name cannot be null or empty.");
                }
                firstName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return middleName;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Middle name cannot be null or empty.");
                }
                middleName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Last name cannot be null or empty.");
                }
                lastName = value;
            }
        }

        public string Ssn
        {
            get
            {
                return ssn;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("SSN cannot be null or empty.");
                }
                ssn = value;
            }
        }

        public string PermanentAddress
        {
            get
            {
                return permanentAddress;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Permanent address cannot be null or empty.");
                }
                permanentAddress = value;
            }
        }

        public string MobilePhone
        {
            get
            {
                return mobilePhone;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Mobile phone cannot be null or empty.");
                }
                mobilePhone = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Email cannot be null or empty.");
                }
                email = value;
            }
        }

        public int Year
        {
            get
            {
                return year;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Year must be greater than 0.");
                }
                year = value;
            }
        }

        public Speciality Speciality
        {
            get
            {
                return speciality;
            }
            private set
            {
                speciality = value;
            }
        }

        public School School
        {
            get
            {
                return school;
            }
            private set
            {
                school = value;
            }
        }

        public University University
        {
            get
            {
                return university;
            }
            private set
            {
                university = value;
            }
        }

        #endregion

        #region Constructors

        public Student(
            string firstName,
            string middleName,
            string lastName,
            string ssn,
            string permanentAddress,
            string mobilePhone,
            string email,
            int year,
            Speciality speciality,
            University university,
            School school)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Ssn = ssn;
            this.PermanentAddress = permanentAddress;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Year = year;
            this.Speciality = speciality;
            this.University = university;
            this.School = school;
        }

        #endregion

        #region Overrides

        public override string ToString()
        {
            return String.Format(
                "Student:\r\nName: {0} {1} {2}\r\nSSN: {3}\r\n" +
                "Permanent address: {4}\r\nMobile phone: {5}\r\nEmail: {6}\r\n" +
                "Year: {7}\r\nSpeciality: {8}\r\nUniversity: {9}\r\nSchool: {10}",
                this.firstName,
                this.middleName,
                this.lastName,
                this.ssn,
                this.permanentAddress,
                this.mobilePhone,
                this.email,
                this.year,
                this.speciality,
                this.university,
                this.school);
        }

        public override bool Equals(object obj)
        {
            // If the cast is invalid, the result will be null
            Student other = obj as Student;

            // Check if we have valid not null Student object
            if (other == null)
            {
                return false;
            }

            bool equals =
                (this.firstName == other.firstName) &&
                (this.middleName == other.middleName) &&
                (this.lastName == other.lastName) &&
                (this.ssn == other.ssn);
            return equals;
        }

        public static bool operator ==(Student studentA, Student studentB)
        {
            return Student.Equals(studentA, studentB);
        }

        public static bool operator !=(Student studentA, Student studentB)
        {
            return !(Student.Equals(studentA, studentB));
        }

        public override int GetHashCode()
        {
            int hashCode =
                this.firstName.GetHashCode() ^
                this.middleName.GetHashCode() ^
                this.lastName.GetHashCode() ^
                this.ssn.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Explicit implementation of ICloneable.Clone()
        /// </summary>
        /// <returns></returns>
        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public Student Clone()
        {
            Student clone = new Student(
                this.firstName,
                this.middleName,
                this.lastName,
                this.ssn,
                this.permanentAddress,
                this.mobilePhone,
                this.email,
                this.year,
                this.speciality,
                this.university,
                this.school);

            return clone;
        }

        public int CompareTo(Student other)
        {
            String thisFullName = String.Format("{0}{1}{2}",
                this.firstName, this.middleName, this.lastName);

            String otherFullName = String.Format("{0}{1}{2}",
                other.firstName, other.middleName, other.lastName);

            int namesCompareResult = String.Compare(thisFullName, otherFullName);

            if (namesCompareResult != 0)
            {
                return namesCompareResult;
            }
            else
            {
                int ssnCompareResult = String.Compare(this.ssn, other.ssn);
                return ssnCompareResult;
            }
        }

        #endregion
    }
}
