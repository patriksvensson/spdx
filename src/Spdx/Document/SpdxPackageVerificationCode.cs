namespace Spdx.Document;

/// <summary>
/// Represents a SPDX package verification code.
/// </summary>
public sealed class SpdxPackageVerificationCode
{
    /// <summary>
    /// Gets or sets the package verification code value.
    /// </summary>
    public string Value { get; set; } = null!;

    /// <summary>
    /// Gets or sets the excluded files.
    /// </summary>
    public List<string> ExcludedFiles { get; set; } = new List<string>();
}
