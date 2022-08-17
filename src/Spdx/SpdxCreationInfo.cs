namespace Spdx;

public sealed class SpdxCreationInfo : ISpdxValidatable
{
    public List<SpdxCreator> Creators { get; init; }
    public DateTimeOffset? Created { get; set; }
    public string? Comment { get; set; }
    public string? LicenseListVersion { get; set; } = SpdxLicense.LicenseListVersion;

    public SpdxCreationInfo()
    {
        Creators = new List<SpdxCreator>();
        Created = DateTimeOffset.Now;
    }

    void ISpdxValidatable.Validate(SpdxValidationContext context)
    {
        if (Creators.Count == 0)
        {
            context.AddError("No creators in document creation info");
        }

        if (Created == null)
        {
            context.AddError("Document creation timestamp is not set");
        }
    }
}
