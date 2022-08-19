namespace Spdx.Document;

/// <summary>
/// Represents SPDX creation info.
/// </summary>
public sealed class SpdxCreationInfo
{
    /// <summary>
    /// Gets or sets the version of the SPDX License List used when
    /// the SPDX document was created.
    /// </summary>
    public string LicenseListVersion { get; set; } = SpdxLicense.LicenseListVersion;

    /// <summary>
    /// Gets or sets the date and time when the SPDX document was originally created.
    /// The date is to be specified according to combined date and time in UTC format as
    /// specified in ISO 8601 standard. This field is distinct from the fields in
    /// <see href="https://spdx.github.io/spdx-spec/annotations/">Clause 12</see>,
    /// which involves the addition of information during a subsequent review.
    /// </summary>
    public DateTimeOffset? Created { get; set; }

    /// <summary>
    /// Gets or sets who (or what, in the case of a tool) created the SPDX document.
    /// If the SPDX document was created by an individual, indicate the person's name.
    /// If the SPDX document was created on behalf of a company or organization,
    /// indicate the entity name. If the SPDX document was created using a software tool,
    /// indicate the name and version for that tool. If multiple participants or tools were involved,
    /// use multiple instances of this field. Person name or organization name may be
    /// designated as <c>anonymous</c> if appropriate.
    /// </summary>
    public List<string> Creators { get; set; } = new List<string>();
}
