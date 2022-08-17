using Spdx.Internal;

namespace Spdx;

public sealed class SpdxCreationInfoBuilder
{
    public List<SpdxCreator> Creators { get; }
    public DateTimeOffset? Created { get; set; }
    public string? Comment { get; set; }
    public string? LicenseListVersion { get; set; }

    public SpdxCreationInfoBuilder()
    {
        Creators = new List<SpdxCreator>();
    }

    internal SpdxCreationInfo? Build(SpdxBuilderContext context)
    {
        using (var scope = context.CreateScope("SpdxCreationInfo"))
        {
            if (Creators.Count == 0)
            {
                context.AddError("SPDX document has no creators");
            }

            if (scope.HasErrors)
            {
                return null;
            }

            return new SpdxCreationInfo(Creators, Created ?? DateTimeOffset.Now);
        }
    }
}