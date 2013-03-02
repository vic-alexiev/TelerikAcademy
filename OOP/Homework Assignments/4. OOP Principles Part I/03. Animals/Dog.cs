public class Dog : Animal, IVocal
{
    public Dog(string name, int age, bool isMale)
        : base(name, age, isMale)
    {
    }

    public string GetTypicalSound()
    {
        return "woof, woof";
    }
}
