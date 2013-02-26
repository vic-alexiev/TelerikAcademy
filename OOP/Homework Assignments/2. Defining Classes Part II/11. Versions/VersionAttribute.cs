using System;

[AttributeUsage(AttributeTargets.Struct |
    AttributeTargets.Class |
    AttributeTargets.Interface |
    AttributeTargets.Enum |
    AttributeTargets.Method)]
public sealed class VersionAttribute : Attribute
{
    private string version;
    private string comment;

    public string Version
    {
        get
        {
            return this.version;
        }
    }

    public string Comment
    {
        get
        {
            return comment;
        }
    }

    public VersionAttribute(string version, string comment)
    {
        this.version = version;
        this.comment = comment;
    }

    public VersionAttribute(string version)
        : this(version, String.Empty)
    {
    }
}