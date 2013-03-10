using System;

namespace PersonInfo
{
    public class Person
    {
        private string name;
        private int? age;

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or empty.");
                }
                name = value;
            }
        }

        public int? Age
        {
            get
            {
                return age;
            }
            private set
            {
                if (value.HasValue && value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Age must be positive.");
                }
                age = value;
            }
        }

        public Person(string name, DateTime? dateOfBirth)
        {
            this.Name = name;
            if (dateOfBirth.HasValue)
            {
                this.Age = CalculateAge(dateOfBirth.Value, DateTime.UtcNow);
            }
        }

        public Person(string name)
            : this(name, null)
        {
        }

        #region Overrides

        public override string ToString()
        {
            return String.Format("Person(Name: {0}, Age: {1})",
                this.name, this.age.HasValue ? this.age.ToString() : "[unspecified]");
        }

        #endregion

        #region Private Methods

        private int CalculateAge(DateTime dateOfBirth, DateTime now)
        {
            int age = now.Year - dateOfBirth.Year;

            if (now.Month < dateOfBirth.Month ||
                now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day)
            {
                age--;
            }

            return age;
        }

        #endregion
    }
}
