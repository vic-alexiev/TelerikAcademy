public class Tomcat : Cat
{
    public Tomcat(string name, int age)
        :base(name, age, true)
    {
    }

    public override string GetTypicalSound()
    {
        return "purr";
    }
}
