using System.Collections.Generic;
using System.Text;

public class School
{
    public string Name { get; private set; }

    public List<SchoolClass> Classes { get; private set; }

    public School(string name, SchoolClass[] classes)
    {
        this.Name = name;
        this.Classes = new List<SchoolClass>(classes);
    }

    public override string ToString()
    {
        StringBuilder schoolInfoBuilder = new StringBuilder();

        schoolInfoBuilder.AppendFormat("School: {0}", this.Name);

        foreach (SchoolClass schoolClass in this.Classes)
        {
            schoolInfoBuilder.AppendFormat("\r\n{0}", schoolClass);
        }

        return schoolInfoBuilder.ToString();
    }
}
