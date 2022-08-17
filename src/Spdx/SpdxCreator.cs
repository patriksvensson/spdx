namespace Spdx;

public abstract class SpdxCreator
{
    public string Name { get; }

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

public sealed class SpdxPerson : SpdxCreator
{
    public string? Email { get; }

    public static SpdxPerson Anonymous { get; } = new SpdxPerson("anonymous", null);

    public SpdxPerson(string name, string? email)
        : base(name)
    {
        Email = email;
    }

    public override string ToString()
    {
        return $"Person: {Name} ({Email})";
    }
}

public sealed class SpdxOrganization : SpdxCreator
{
    public string? Email { get; }

    public static SpdxOrganization Anonymous { get; } = new SpdxOrganization("anonymous", null);

    public SpdxOrganization(string name, string? email)
        : base(name)
    {
        Email = email;
    }

    public override string ToString()
    {
        return $"Organization: {Name} ({Email})";
    }
}

public sealed class SpdxTool : SpdxCreator
{
    public string Version { get; }

    public SpdxTool(string name, string version)
        : base(name)
    {
        Version = version ?? throw new ArgumentNullException(nameof(version));
    }

    public override string ToString()
    {
        return $"Tool: {Name}-{Version}";
    }
}