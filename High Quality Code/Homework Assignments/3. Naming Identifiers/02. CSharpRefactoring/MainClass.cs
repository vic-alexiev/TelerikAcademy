/// <summary>
/// The main class of the application.
/// </summary>
internal class MainClass
{
    /// <summary>
    /// Keeps the person's sex (male or female).
    /// </summary>
    private enum Sex
    {
        /// <summary>
        /// sex - male
        /// </summary>
        Male,

        /// <summary>
        /// sex - female
        /// </summary>
        Female
    }

    /// <summary>
    /// Creates a <see cref="Person"/> object and sets its properties
    /// depending on the specified age.
    /// </summary>
    /// <param name="age">The age of the person which will be created.</param>
    public void CreatePerson(int age)
    {
        Person person = new Person();
        person.Age = age;

        if (age % 2 == 0)
        {
            person.Name = "Yordan Yovchev";
            person.Sex = Sex.Male;
        }
        else
        {
            person.Name = "Stanka Zlateva";
            person.Sex = Sex.Female;
        }
    }

    /// <summary>
    /// The entry point of the program.
    /// </summary>
    private static void Main()
    {
        // nothing to do
    }

    /// <summary>
    /// Represents a person.
    /// </summary>
    private class Person
    {
        /// <summary>
        /// Gets or sets the sex of the person.
        /// </summary>
        public Sex Sex { get; set; }

        /// <summary>
        /// Gets or sets the name of the person.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the age of the person.
        /// </summary>
        public int Age { get; set; }
    }
}
