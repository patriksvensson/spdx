namespace Spdx.Document;

/// <summary>
/// Represents an SPDX external reference.
/// </summary>
public class SpdxExternalReference
{
    /// <summary>
    /// Gets or sets the external reference category.
    /// <para>Must be one of the following values:</para>
    /// <list type="bullet">
    ///     <item>SECURITY</item>
    ///     <item>PACKAGE-MANAGER</item>
    ///     <item>PERSISTENT-ID</item>
    ///     <item>OTHER</item>
    /// </list>
    /// </summary>
    public string Category { get; set; } = null!;

    /// <summary>
    /// Gets or sets one of the types listed in
    /// <see href="https://spdx.github.io/spdx-spec/external-repository-identifiers/">Annex F</see>.
    /// </summary>
    public string Type { get; set; } = null!;

    /// <summary>
    /// Gets or sets the unique string with no spaces necessary to access the package-specific information,
    /// metadata, or content within the target location. The format of the locator is subject to
    /// constraints defined by the <see cref="Type"/> property.
    /// </summary>
    public string Locator { get; set; } = null!;
}
