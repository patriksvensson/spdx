namespace Spdx;

public sealed class SpdxDocumentUri
{
    public string Scheme { get; }
    public string Website { get; }
    public string PathToSpdx { get; }
    public string DocumentName { get; }
    public string UUID { get; }

    private SpdxDocumentUri(string scheme, string creatorWebsite, string pathToSpdx, string documentName, string uuid)
    {
        Scheme = scheme;
        Website = creatorWebsite;
        PathToSpdx = pathToSpdx;
        DocumentName = documentName;
        UUID = uuid;
    }

    public static SpdxDocumentUri FromUri(string uri, Guid? uuid = null)
    {
        return FromUri(new UriBuilder(uri).Uri, uuid);
    }

    public static SpdxDocumentUri FromUri(Uri uri, Guid? uuid = null)
    {
        if (uri is null)
        {
            throw new ArgumentNullException(nameof(uri));
        }

        var scheme = uri.Scheme;
        var website = uri.GetLeftPart(UriPartial.Authority).Substring(scheme.Length + 3);

        var parts = uri.PathAndQuery.TrimStart('/').Split('/', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 0)
        {
            throw new InvalidOperationException("Uri is missing path");
        }
        else if (parts.Length == 1)
        {
            throw new InvalidOperationException("Uri is missing document ID");
        }

        var path = string.Join("/", parts.Take(parts.Length - 1));

        var documentId = parts.Last();
        if (documentId.Length > 37 && Guid.TryParse(documentId.AsSpan(documentId.Length - 36), out var tempUuid))
        {
            documentId = documentId.Substring(0, documentId.Length - 37);
            if (uuid == null)
            {
                // Replace the existing one
                uuid = tempUuid;
            }
        }

        uuid ??= Guid.NewGuid();

        return new SpdxDocumentUri(scheme, website, path, documentId, uuid.Value.ToString("D").ToUpperInvariant());
    }

    public static SpdxDocumentUri FromDocumentName(string documentName, Guid? uuid = null)
    {
        uuid ??= Guid.NewGuid();
        return new SpdxDocumentUri("http", "spdx.org", "spdxdocs", documentName, uuid.Value.ToString("D").ToUpperInvariant());
    }

    public override string ToString()
    {
        return $"{Scheme}://{Website}/{PathToSpdx}/{DocumentName}-{UUID}";
    }
}
