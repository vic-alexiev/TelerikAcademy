using System;
using System.Reflection;

[Version("1.0", "This is a demo class.")]
class VersionsDemo
{
    [Version("1.1")]
    private enum DemoConfiguration
    {
        Debug = 0,
        Release = 1,
    }

    [Version("8.19", "A demo method written by Anonymous.")]
    private static void DoNothing()
    {
    }

    [Version("12.6")]
    private static bool ReturnTrue()
    {
        return true;
    }

    [Version("6.67", "The entry point.")]
    static void Main()
    {
        Type type = typeof(VersionsDemo);

        object[] customAttributes = type.GetCustomAttributes(false);

        if (customAttributes.Length > 0)
        {
            Console.WriteLine("This class has version {0} with comment \"{1}\"",
                (customAttributes[0] as VersionAttribute).Version,
                (customAttributes[0] as VersionAttribute).Comment);
        }

        MethodInfo[] methods = type.GetMethods(BindingFlags.Static | BindingFlags.NonPublic);

        foreach (MethodInfo method in methods)
        {
            object[] methodAttributes = method.GetCustomAttributes(false);

            if (methodAttributes.Length > 0 && methodAttributes[0] is VersionAttribute)
            {
                Console.WriteLine("Method \"{0}\" has version {1} with comment \"{2}\"",
                    method.Name,
                    (methodAttributes[0] as VersionAttribute).Version,
                    (methodAttributes[0] as VersionAttribute).Comment);
            }
        }

        Type enumType = type.GetNestedType("DemoConfiguration", BindingFlags.NonPublic);

        object[] enumCustomAttributes = enumType.GetCustomAttributes(false);

        if (enumCustomAttributes.Length > 0 && enumCustomAttributes[0] is VersionAttribute)
        {
            Console.WriteLine("Nested type \"{0}\" has version {1} with comment \"{2}\"",
                enumType.Name,
                (enumCustomAttributes[0] as VersionAttribute).Version,
                (enumCustomAttributes[0] as VersionAttribute).Comment);
        }
    }
}
