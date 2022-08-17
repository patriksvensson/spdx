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
