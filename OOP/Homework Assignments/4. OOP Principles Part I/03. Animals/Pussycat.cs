public class Pussycat : Cat
{
    public Pussycat(string name, int age)
        :base(name, age, false)
    {
    }

    public override string GetTypicalSound()
    {
        return "meow";
    }
}
