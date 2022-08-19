namespace Spdx.Generator.Models;

public sealed class SpdxLicenseManifest
{
    [JsonPropertyName("licenseListVersion")]
    public string LicenseListVersion { get; set; } = null!;

    [JsonPropertyName("licenses")]
    public List<SpdxLicenseModel> Licenses { get; set; } = null!;
}
