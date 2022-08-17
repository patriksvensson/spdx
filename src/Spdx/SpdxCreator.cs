namespace Spdx;

public abstract class SpdxCreator
{
    public string Name { get; }

    public static SpdxCreator Anonymous { get; } = new SpdxAnonymousCreator();

    protected SpdxCreator(string name)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
    }

    public static SpdxCreator Person(string name, string? email = null)
    {
        return new SpdxPerson(name, email);
    }

    public static SpdxCreator Organization(string name, string? email = null)
    {
        return new SpdxOrganization(name, email);
    }

    public static SpdxCreator Tool(string name, string version)
    {
        return new SpdxTool(name, version);
    }
}

public sealed class SpdxAnonymousCreator : SpdxCreator
{
    public SpdxAnonymousCreator()
        : base("anonymous")
    {
    }
}

public sealed class SpdxPerson : SpdxCreator
{
    public string? Email { get; }

    public SpdxPerson(string name, string? email)
        : base(name)
    {
        Email = email;
    }
}

public sealed class SpdxOrganization : SpdxCreator
{
    public string? Email { get; }

    public SpdxOrganization(string name, string? email)
        : base(name)
    {
        Email = email;
    }
}

public sealed class SpdxTool : SpdxCreator
{
    public string Version { get; }

    public SpdxTool(string name, string version)
        : base(name)
    {
        Version = version;
    }
}