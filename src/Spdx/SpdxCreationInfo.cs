using Spdx.Internal;

namespace Spdx;

public sealed class SpdxCreationInfo
{
    public List<SpdxCreator> Creators { get; }
    public DateTimeOffset Created { get; }
    public string? Comment { get; set; }
    public string? LicenseListVersion { get; set; }

    public SpdxCreationInfo(IEnumerable<SpdxCreator> creators, DateTimeOffset created)
    {
        Creators = new List<SpdxCreator>(creators ?? throw new ArgumentNullException(nameof(creators)));
        Created = created;
    }
}

public sealed class SpdxCreationInfoBuilder
{
    public List<SpdxCreator> Creators { get; }
    public DateTimeOffset? Created { get; }
    public string? Comment { get; set; }
    public string? LicenseListVersion { get; set; }

    public SpdxCreationInfoBuilder()
    {
        Creators = new List<SpdxCreator>();
    }

    internal bool TryBuild(SpdxBuilderContext context, [NotNullWhen(true)] out SpdxCreationInfo? info)
    {
        using (var scope = context.CreateScope("SpdxCreationInfo"))
        {
            if (Creators.Count == 0)
            {
                context.AddError("SPDX document has no creators");
            }

            if (Created == null)
            {
                context.AddError("Created date has not been set.");
            }

            if (scope.HasErrors)
            {
                info = null;
                return false;
            }

            info = new SpdxCreationInfo(Creators, Created!.Value);
            return true;
        }
    }
}