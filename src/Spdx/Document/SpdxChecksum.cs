namespace Spdx.Document;

/// <summary>
/// Represents a SPDX checksum.
/// </summary>
public sealed class SpdxChecksum
{
    /// <summary>
    /// Gets or sets the algorithm identifier.
    /// </summary>
    public string Algorithm { get; set; } = null!;

    /// <summary>
    /// Gets or sets the checksum.
    /// </summary>
    public string Value { get; set; } = null!;
}
