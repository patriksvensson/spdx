namespace Spdx;

public sealed class SpdxDocument
{
    // Constants
    public string Version { get; } = "SPDX-2.2";
    public string DataLicense { get; } = "CC0-1.0";

    // Required
    public string Identifier { get; }
    public string Name { get; }
    public SpdxDocumentUri Namespace { get; }
    public SpdxCreationInfo CreationInfo { get; }

    // Optional
    public IReadOnlyList<SpdxExternalDocumentRef> ExternalDocumentRefs { get; }
    public string? Comment { get; }

    public SpdxDocument(
        string identifier,
        string name,
        SpdxDocumentUri @namespace,
        SpdxCreationInfo creationInfo,
        IEnumerable<SpdxExternalDocumentRef> externalDocumentRefs,
        string? comment)
    {
        Identifier = identifier ?? throw new ArgumentNullException(nameof(identifier));
        Name = name ?? throw new ArgumentNullException(nameof(name));
        Namespace = @namespace ?? throw new ArgumentNullException(nameof(@namespace));
        CreationInfo = creationInfo ?? throw new ArgumentNullException(nameof(creationInfo));
        ExternalDocumentRefs = new List<SpdxExternalDocumentRef>(externalDocumentRefs);
        Comment = comment;
    }
}
