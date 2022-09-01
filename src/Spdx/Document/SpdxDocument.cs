namespace Spdx.Document;

/// <summary>
/// Represents a SPDX document.
/// </summary>
public class SpdxDocument
    : SpdxDocument<SpdxPackage, SpdxFile, SpdxRelationship, SpdxExtractedLicense>
{
}

/// <summary>
/// Represents a SPDX document.
/// </summary>
/// <typeparam name="TPackage">The package type.</typeparam>
/// <typeparam name="TFile">The file type.</typeparam>
/// <typeparam name="TRelationship">The relationship type</typeparam>
/// <typeparam name="TExtractedLicense">The extracted license type</typeparam>
public class SpdxDocument<TPackage, TFile, TRelationship, TExtractedLicense>
    where TPackage : SpdxPackage
    where TFile : SpdxFile
    where TRelationship : SpdxRelationship
    where TExtractedLicense : SpdxExtractedLicense
{
    /// <summary>
    /// Gets or sets a reference number that can be used to understand how to parse and
    /// interpret the rest of the file. It will enable both future changes to the
    /// specification and to support backward compatibility.
    /// The version number consists of a major and minor version indicator.
    /// The major field shall be incremented when incompatible changes between
    /// versions are made (one or more sections are created, modified or deleted).
    /// </summary>
    /// <example>SPDX-2.2</example>
    public string SpdxVersion { get; set; } = "SPDX-2.3";

    /// <summary>
    /// Gets or sets the data license.
    /// Compliance with this document includes populating the SPDX fields therein with
    /// data related to such fields ("SPDX-Metadata"). This document contains numerous
    /// fields where an SPDX document creator may provide relevant explanatory text in
    /// SPDX-Metadata. Without opining on the lawfulness of "database rights"
    /// (in jurisdictions where applicable), such explanatory text is copyrightable
    /// subject matter in most Berne Convention countries. By using the SPDX specification,
    /// or any portion hereof, you hereby agree that any copyright rights
    /// (as determined by your jurisdiction) in any SPDX-Metadata, including without
    /// limitation explanatory text, shall be subject to the terms of the
    /// Creative Commons CC0 1.0 Universal license. For SPDX-Metadata not containing
    /// any copyright rights, you hereby agree and acknowledge that the SPDX-Metadata
    /// is provided to you “as-is” and without any representations or warranties of any
    /// kind concerning the SPDX-Metadata, express, implied, statutory or otherwise,
    /// including without limitation warranties of title, merchantability, fitness for a
    /// particular purpose, non-infringement, or the absence of latent or other defects,
    /// accuracy, or the presence or absence of errors, whether or not discoverable,
    /// all to the greatest extent permissible under applicable law.
    /// </summary>
    /// <example>CC0-1.0</example>
    public string DataLicense { get; set; } = "CC0-1.0";

    /// <summary>
    /// Gets or sets the identifier of the current SPDX document which may be referenced
    /// in relationships by other files packages internally and documents externally.
    /// To reference another SPDX document in total, this identifier should be used with
    /// the external document identifier preceding it.
    /// </summary>
    /// <example>SPDXRef-DOCUMENT</example>
    public string SpdxId { get; set; } = "SPDXRef-DOCUMENT";

    /// <summary>
    /// Gets or sets the name of this document as designated by creator.
    /// </summary>
    public string DocumentName { get; set; } = null!;

    /// <summary>
    /// <para>
    /// Gets or sets an SPDX document-specific namespace as a unique absolute
    /// Uniform Resource Identifier (URI) as specified in RFC-3986, with the exception of
    /// the ‘#’ delimiter. The SPDX document URI shall not contain a URI "part"
    /// (e.g. the "#" character), since the ‘#’ is used in SPDX element URIs
    /// (packages, files, snippets, etc) to separate the document namespace from the
    /// element’s SPDX identifier. Additionally, a scheme (e.g. “https:”) is required.
    /// </para>
    /// <para>
    /// The URI shall be unique for the SPDX document including the specific version of the
    /// SPDX document.If the SPDX document is updated, thereby creating a new version,
    /// a new URI for the updated document shall be used.There may only be one URI for an
    /// SPDX document and only one SPDX document for a given URI.
    /// </para>
    /// </summary>
    /// <example>http://spdx.org/spdxdocs/hades-v1.2-9906A8B7-A923-40B6-ACC1-4D36F7E1FF6D</example>
    public string DocumentNamespace { get; set; } = null!;

    /// <summary>
    /// Gets or sets the creation info for the document.
    /// </summary>
    public SpdxCreationInfo CreationInfo { get; set; } = new SpdxCreationInfo();

    /// <summary>
    /// Gets or sets the document's packages.
    /// </summary>
    public List<TPackage> Packages { get; set; } = new List<TPackage>();

    /// <summary>
    /// Gets or sets the document's files.
    /// </summary>
    public List<TFile> Files { get; set; } = new List<TFile>();

    /// <summary>
    /// Gets or sets the relationships between the document's entities (packages, files, etc).
    /// </summary>
    public List<TRelationship> Relationships { get; set; } = new List<TRelationship>();

    /// <summary>
    /// Gets or sets the extracted licenses.
    /// </summary>
    public List<TExtractedLicense> ExtractedLicenses { get; set; } = new List<TExtractedLicense>();

    /// <summary>
    /// Serializes the SPDX document to JSON.
    /// </summary>
    /// <param name="format">The SPDX document output format.</param>
    /// <returns>A string containing the serialized representation of the SPDX document.</returns>
    public string Serialize(SpdxDocumentFormat format)
    {
        var result = SpdxSerializer.Serialize(this, format, out var report, out var output, out var exception);
        if (result)
        {
            return output!;
        }

        if (exception != null)
        {
            throw new SpdxSerializationException("An error occured during serialization", exception);
        }
        else
        {
            throw new SpdxSerializationException("The SPDX document is not valid. See report for more information", report);
        }
    }

    /// <summary>
    /// Serializes the SPDX document to the specified format.
    /// A return value indicates whether the conversion succeeded.
    /// </summary>
    /// <param name="format">The SPDX document output format.</param>
    /// <param name="output">
    /// A string containing the serialized representation of the SPDX document,
    /// or <c>null</c> if serialization failed.
    /// </param>
    /// <returns>
    /// <c>true</c> if the SPDX document was serialized successfully;
    /// otherwise, <c>false</c>.
    /// </returns>
    public bool TrySerialize(SpdxDocumentFormat format, out string? output)
    {
        return SpdxSerializer.Serialize(this, format, out _, out output, out _);
    }

    /// <summary>
    /// Performs validation of the current document.
    /// </summary>
    /// <returns>A <see cref="SpdxValidationReport"/>.</returns>
    public SpdxValidationReport Validate()
    {
        var context = new SpdxValidationContext();
        SpdxValidator.Validate(context, this);
        return context.CreateReport();
    }
}
