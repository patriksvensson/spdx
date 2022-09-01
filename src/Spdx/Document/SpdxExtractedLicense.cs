namespace Spdx.Document;

/// <summary>
/// Represents an extracted (non SPDX) license.
/// </summary>
public class SpdxExtractedLicense
{
    /// <summary>
    /// Gets or sets an unique identifier to refer to licenses that are not found on the
    /// SPDX License List. This unique identifier can then be used in the packages,
    /// files and snippets sections of the SPDX document.
    /// </summary>
    public string LicenseId { get; set; } = null!;

    /// <summary>
    /// Gets or sets a copy of the actual text of the license reference extracted
    /// from the package, file or snippet that is associated with the
    /// license identifier to aid in future analysis.
    /// </summary>
    public string ExtractedText { get; set; } = null!;

    /// <summary>
    /// Gets or sets a common name of the license that is not on the SPDX list.
    /// <para>
    /// Use <term>NOASSERTION</term> If there is no common name or it is not known.
    /// </para>
    /// </summary>
    public string LicenseName { get; set; } = null!;

    /// <summary>
    /// Gets or sets pointers to the official source of a license that is
    /// not included in the SPDX License List, that is referenced by the license identifier.
    /// </summary>
    public List<string> LicenseCrossReference { get; set; } = new List<string>();

    /// <summary>
    /// Gets or sets a comments about the license.
    /// </summary>
    public string LicenseComment { get; set; } = null!;
}
