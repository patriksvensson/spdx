namespace Spdx;

public sealed class SpdxExternalDocumentRef
{
    public string Identifier { get; }
    public SpdxDocumentUri DocumentUri { get; }
    public SpdxChecksum Checksum { get; }

    public SpdxExternalDocumentRef(string identifier, SpdxDocumentUri documentUri, SpdxChecksum checksum)
    {
        Identifier = identifier ?? throw new ArgumentNullException(nameof(identifier));
        DocumentUri = documentUri ?? throw new ArgumentNullException(nameof(documentUri));
        Checksum = checksum ?? throw new ArgumentNullException(nameof(checksum));
    }
}
