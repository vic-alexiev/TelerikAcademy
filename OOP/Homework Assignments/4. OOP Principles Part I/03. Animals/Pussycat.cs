public class Pussycat : Cat, IVocal
{
    public Pussycat(string name, int age)
        : base(name, age, false)
    {
    }

    public string GetTypicalSound()
    {
        return "meow";
    }
}
