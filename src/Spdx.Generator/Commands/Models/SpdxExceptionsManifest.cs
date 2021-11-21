namespace Spdx.Generator.Models;

public sealed class SpdxExceptionsManifest
{
    [JsonPropertyName("exceptions")]
    public List<SpdxExceptionModel> Exceptions { get; set; } = null!;
}
