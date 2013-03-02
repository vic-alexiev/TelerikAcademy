public class Kitten : Cat, IVocal
{
    public Kitten(string name, int age, bool isMale)
        : base(name, age, isMale)
    {
    }

    public string GetTypicalSound()
    {
        return "miaou";
    }
}
