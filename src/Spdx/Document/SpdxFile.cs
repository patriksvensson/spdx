namespace Spdx.Document;

/// <summary>
/// Represents a SPDX file.
/// </summary>
public class SpdxFile
{
    /// <summary>
    /// Gets or sets the full path and filename that corresponds to the file
    /// information in this section.
    /// </summary>
    public string Filename { get; set; } = null!;

    /// <summary>
    /// Gets or sets an identifier for any element in an SPDX document which
    /// might be referenced by other elements. These might be referenced
    /// internally and externally with the addition of the SPDX document identifier.
    /// </summary>
    public string SpdxId { get; set; } = null!;

    /// <summary>
    /// Gets or sets the result from some specific checksum algorithm.
    /// Checksum algorithms consume data from the file and produce a short, fix-sized summary that
    /// is sensitive to changes in the file's data. Any random change to the file's data will
    /// (with high likelihood) result in a different checksum value.
    /// </summary>
    public List<SpdxChecksum> Checksums { get; set; } = new List<SpdxChecksum>();

    /// <summary>
    /// Gets or sets the license the SPDX document creator has concluded as governing the file
    /// or alternative values, if the governing license cannot be determined.
    /// <para>The options to populate this field are limited to:</para>
    /// <list type="number">
    ///     <item>A valid SPDX License Expression as defined in <see href="https://spdx.github.io/spdx-spec/SPDX-license-expressions/">Annex D</see>;</item>
    ///     <item><term>NONE</term> if the SPDX document creator concludes there is no license available for this file; or</item>
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
    /// <para>
    /// Gets or sets the license information actually found in the file, if any.
    /// This information is most commonly found in the header of the file, although it
    /// might be in other areas of the actual file. Any license information not actually
    /// in the file, e.g., <c>COPYING.txt</c> file in a top-level directory,
    /// should not be reflected in this field.
    /// </para>
    /// <para>The options to populate this field are limited to:</para>
    /// <list type="number">
    ///     <item>
    ///         The SPDX License List short form identifier, if the license is on the SPDX License List;
    ///         A reference to the license, denoted by <c>LicenseRef-{idstring}</c>,
    ///         if the license is not on the SPDX License List;
    ///     </item>
    ///     <item><term>NONE</term> if the file contains no license information whatsoever; or</item>
    ///     <item><term>NOASSERTION</term>, if
    ///         <list type="bullet">
    ///             <item>the SPDX document creator has made no attempt to determine this field; or</item>
    ///             <item>the SPDX document creator has intentionally provided no information (no meaning should be implied by doing so).</item>
    ///         </list>
    ///     </item>
    /// </list>
    /// <para>
    /// If license information for more than one license is contained in the file or if the
    /// license information offers the package recipient a choice of licenses,
    /// then each of the choices should be listed as a separate entry.
    /// </para>
    /// </summary>
    public List<string> LicenseInfoInFiles { get; set; } = new List<string>();

    /// <summary>
    /// Gets or sets the copyright holders of the file, as well as any dates present.
    /// This shall be a free form-text field extracted from the actual file.
    /// <para>The options to populate this field are limited to:</para>
    /// <list type="number">
    ///     <item>Any text related to a copyright notice, even if not complete;</item>
    ///     <item><term>NONE</term> if the file contains no copyright information whatsoever; or</item>
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
    /// Gets or sets information about the type of file identified.
    /// File Type is intrinsic to the file, independent of how the file is being used.
    /// A file may have more than one file type assigned to it, however the options
    /// to populate this field are limited to:
    /// <list type="bullet">
    ///     <item><term>SOURCE</term> if the file is human readable source code (<c>.c</c>, <c>.html</c>, etc.);</item>
    ///     <item><term>BINARY</term> if the file is a compiled object, target image or binary executable (<c>.o</c>, <c>.a</c>, etc.);</item>
    ///     <item><term>ARCHIVE</term> if the file represents an archive (<c>.tar</c>, <c>.jar</c>, etc.);</item>
    ///     <item><term>APPLICATION</term> if the file is associated with a specific application type (MIME type of <c>application/*</c>);</item>
    ///     <item><term>AUDIO</term> if the file is associated with an audio file (MIME type of <c>audio/*</c> , e.g. <c>.mp3</c>);</item>
    ///     <item><term>IMAGE</term> if the file is associated with a picture image file (MIME type of <c>image/*</c>, e.g., <c>.jpg</c>, <c>.gif</c>);</item>
    ///     <item><term>TEXT</term> if the file is human readable text file (MIME type of <c>text/*</c>);</item>
    ///     <item><term>VIDEO</term> if the file is associated with a video file type (MIME type of <c>video/*</c>);</item>
    ///     <item><term>DOCUMENTATION</term> if the file serves as documentation;</item>
    ///     <item><term>SPDX</term> if the file is an SPDX document;</item>
    ///     <item><term>OTHER</term> if the file doesn't fit into the above categories (generated artifacts, data files, etc.)</item>
    /// </list>
    /// </summary>
    public List<string> FileTypes { get; set; } = new List<string>();
}