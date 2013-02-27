public class Dog : Animal
{
    public Dog(string name, int age, bool isMale)
        : base(name, age, isMale)
    {
    }

    public override string GetTypicalSound()
    {
        return "woof, woof";
    }
}
