public class Frog : Animal, IVocal
{
    public Frog(string name, int age, bool isMale)
        : base(name, age, isMale)
    {
    }

    public string GetTypicalSound()
    {
        return "ribbit, ribbit";
    }
}
