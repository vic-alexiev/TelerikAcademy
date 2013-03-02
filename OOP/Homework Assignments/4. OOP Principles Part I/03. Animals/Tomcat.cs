public class Tomcat : Cat, IVocal
{
    public Tomcat(string name, int age)
        :base(name, age, true)
    {
    }

    public string GetTypicalSound()
    {
        return "purr";
    }
}
