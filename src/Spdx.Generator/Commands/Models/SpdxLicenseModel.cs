namespace Spdx.Generator.Models;

public sealed class SpdxLicenseModel
{
    [JsonPropertyName("licenseId")]
    public string Id { get; set; } = null!;
    [JsonPropertyName("reference")]
    public string Reference { get; set; } = null!;
    [JsonPropertyName("isDeprecatedLicenseId")]
    public bool IsDeprecated { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;
    [JsonPropertyName("detailsUrl")]
    public string Url { get; set; } = null!;
    [JsonPropertyName("isOsiApproved")]
    public bool OsiApproved { get; set; }
    [JsonPropertyName("isFsfLibre")]
    public bool IsFsfLibre { get; set; }
}
