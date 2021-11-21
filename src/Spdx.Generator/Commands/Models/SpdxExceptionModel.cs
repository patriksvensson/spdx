namespace Spdx.Generator.Models;

public sealed class SpdxExceptionModel
{
    [JsonPropertyName("licenseExceptionId")]
    public string Id { get; set; } = null!;
    [JsonPropertyName("reference")]
    public string Reference { get; set; } = null!;
    [JsonPropertyName("isDeprecatedLicenseId")]
    public bool IsDeprecated { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;
    [JsonPropertyName("detailsUrl")]
    public string Url { get; set; } = null!;
}
