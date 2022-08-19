namespace Spdx.Document;

/// <summary>
/// Represents a SPDX Package
/// </summary>
public sealed class SpdxPackage
{
    /// <summary>
    /// Gets or sets an unique identifier for this package which may be referenced by other elements.
    /// These may be referenced internally and externally with the addition of the SPDX document identifier.
    /// </summary>
    public string SpdxId { get; set; } = null!;

    /// <summary>
    /// Gets or sets the name of the package as given by the package originator.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Gets or sets the version of the package.
    /// </summary>
    public string VersionInfo { get; set; } = null!;

    /// <summary>
    /// Gets or sets the actual file name of the package, or path of the directory being treated as a package.
    /// This may include the packaging and compression methods used as part of the file name, if appropriate.
    /// </summary>
    public string PackageFilename { get; set; } = null!;

    /// <summary>
    /// Gets or sets the download Uniform Resource Locator (URL), or a specific location within a
    /// version control system (VCS) for the package at the time that the SPDX document was created.
    /// <para>
    /// Use:
    /// <list type="number">
    ///     <item><term>NONE</term> if there is no download location whatsoever.</item>
    ///     <item><term>NOASSERTION</term>, if
    ///         <list type="bullet">
    ///             <item>the SPDX document creator has attempted to but cannot reach a reasonable objective determination;</item>
    ///             <item>the SPDX document creator has made no attempt to determine this field; or</item>
    ///             <item>the SPDX document creator has intentionally provided no information (no meaning should be implied by doing so).</item>
    ///         </list>
    ///     </item>
    /// </list>
    /// </para>
    /// </summary>
    public string DownloadLocation { get; set; } = null!;

    /// <summary>
    /// Gets or sets a value indicating whether the file content of this package has been available for
    /// or subjected to analysis when creating the SPDX document. If <c>false</c>, indicates packages
    /// that represent metadata or URI references to a project, product, artifact, distribution
    /// or a component. If <c>false</c>, the package shall not contain any files.
    /// </summary>
    public bool FilesAnalyzed { get; set; } = false;

    /// <summary>
    /// Gets or sets an independently reproducible mechanism identifying specific contents of a
    /// package based on the actual files (except the SPDX document itself, if it is included in the package)
    /// that make up each package and that correlates to the data in this SPDX document.
    /// This identifier enables a recipient to determine if any file in the original package
    /// (that the analysis was done on) has been changed and permits inclusion of an
    /// SPDX document as part of a package.
    /// </summary>
    public SpdxPackageVerificationCode PackageVerificationCode { get; set; } = null!;

    /// <summary>
    /// Gets or sets the license the SPDX document creator has concluded as governing the package
    /// or alternative values, if the governing license cannot be determined.
    /// <para>The options to populate this field are limited to:</para>
    /// <list type="number">
    ///     <item>A valid SPDX License Expression as defined in <see href="https://spdx.github.io/spdx-spec/SPDX-license-expressions/">Annex D</see>;</item>
    ///     <item><term>NONE</term> if the SPDX document creator concludes there is no license available for this package; or</item>
    ///     <item><term>NOASSERTION</term>, if
    ///         <list type="bullet">
    ///             <item>the SPDX document creator has attempted to but cannot reach a reasonable objective determination;</item>
    ///             <item>the SPDX document creator has made no attempt to determine this field; or</item>
    ///             <item>the SPDX document creator has intentionally provided no information (no meaning should be implied by doing so).</item>
    ///         </list>
    ///     </item>
    /// </list>
    /// </summary>
    public string LicenseConcluded { get; set; } = null!;

    /// <summary>
    /// Gets or sets the licenses that have been declared by the authors of the package.
    /// Any license information that does not originate from the package authors, e.g.
    /// license information from a third-party repository, should not be included in this field.
    /// </summary>
    public string LicenseDeclared { get; set; } = null!;

    /// <summary>
    /// Gets or sets the copyright holders of the package, as well as any dates present.
    /// This will be a free form text field extracted from package information files.
    /// <para>The options to populate this field are limited to:</para>
    /// <list type="number">
    ///     <item>Any text related to a copyright notice, even if not complete;</item>
    ///     <item><term>NONE</term> if the package contains no copyright information whatsoever; or</item>
    ///     <item><term>NOASSERTION</term>, if
    ///         <list type="bullet">
    ///             <item>the SPDX document creator has made no attempt to determine this field; or</item>
    ///             <item>the SPDX document creator has intentionally provided no information (no meaning should be implied by doing so).</item>
    ///         </list>
    ///     </item>
    /// </list>
    /// </summary>
    public string CopyrightText { get; set; } = null!;

    /// <summary>
    /// Gets or sets a list of all licenses found in the package.
    /// The relationship between licenses (i.e., conjunctive, disjunctive) is not specified in
    /// this field – it is simply a listing of all licenses found.
    /// <para>The options to populate this field are limited to:</para>
    /// <list type="number">
    ///     <item>The SPDX License List short form identifier, if a detected license is on the SPDX License List;</item>
    ///     <item>A user defined license reference denoted by <c>LicenseRef-{idstring}</c> (for a license not on the SPDX License List);</item>
    ///     <item><term>NONE</term> if no license information is detected in any of the files; or</item>
    ///     <item><term>NOASSERTION</term>, if
    ///         <list type="bullet">
    ///             <item>the SPDX document creator has made no attempt to determine this field; or</item>
    ///             <item>the SPDX document creator has intentionally provided no information (no meaning should be implied by doing so).</item>
    ///         </list>
    ///     </item>
    /// </list>
    /// </summary>
    public List<string> LicenseInfoFromFiles { get; set; } = new List<string>();

    /// <summary>
    /// Gets or sets an independently reproducible mechanism that permits unique identification of a
    /// specific package that correlates to the data in this SPDX document. This identifier enables a
    /// recipient to determine if any file in the original package has been changed.
    /// If the SPDX document is to be included in a package, this value should not be calculated.
    /// The SHA-1 algorithm shall be used to provide the checksum by default.
    /// </summary>
    public List<SpdxChecksum> Checksums { get; set; } = new List<SpdxChecksum>();

    /// <summary>
    /// Gets or sets an external reference that allows a Package to reference an external source
    /// of additional information, metadata, enumerations, asset identifiers, or downloadable
    /// content believed to be relevant to the Package.
    /// </summary>
    public List<SpdxExternalReference> ExternalReferences { get; set; } = new List<SpdxExternalReference>();

    /// <summary>
    /// Gets or sets the actual distribution source for the package/directory identified in the SPDX document.
    /// This might or might not be different from the originating distribution source for the package.
    /// The name of the Package Supplier shall be an organization or recognized author and not a web site.
    /// For example, SourceForge is a host website, not a supplier, the supplier
    /// for https://sourceforge.net/projects/bridge/ is "The Linux Foundation".
    /// <para>Use <term>NOASSERTION</term> if:</para>
    /// <list type="bullet">
    ///     <item>the SPDX document creator has attempted to but cannot reach a reasonable objective determination;</item>
    ///     <item>the SPDX document creator has made no attempt to determine this field; or</item>
    ///     <item>the SPDX document creator has intentionally provided no information (no meaning should be implied by doing so).</item>
    /// </list>
    /// </summary>
    public string Supplier { get; set; } = null!;
}
