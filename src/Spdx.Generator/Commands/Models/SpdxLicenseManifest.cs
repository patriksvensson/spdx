namespace Spdx.Generator.Models;

public sealed class SpdxLicenseManifest
{
    [JsonPropertyName("licenses")]
    public List<SpdxLicenseModel> Licenses { get; set; } = null!;
}
