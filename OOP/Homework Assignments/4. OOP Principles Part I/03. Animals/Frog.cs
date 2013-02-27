public class Frog : Animal
{
    public Frog(string name, int age, bool isMale)
        : base(name, age, isMale)
    {
    }

    public override string GetTypicalSound()
    {
        return "ribbit, ribbit";
    }
}
