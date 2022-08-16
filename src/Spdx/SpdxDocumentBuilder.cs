namespace Spdx;

public sealed class SpdxDocumentBuilder
{
    // Required
    public string? Identifier { get; set; }
    public string? Name { get; set; }
    public SpdxDocumentUri? Namespace { get; set; }
    public SpdxCreationInfo? CreationInfo { get; set; }

    // Optional
    public List<SpdxExternalDocumentRef> ExternalDocumentRefs { get; }
    public string? Comment { get; }

    public SpdxDocumentBuilder()
    {
        ExternalDocumentRefs = new List<SpdxExternalDocumentRef>();
    }

    public void SetNamespace(SpdxDocumentUri uri)
    {
        Namespace = uri;
    }

    public void SetCreationInfo(Action<SpdxCreationInfoBuilder> action)
    {
        var builder = new SpdxCreationInfoBuilder();
        action(builder);
        throw new NotImplementedException();
    }

    public SpdxDocument? Build(out IReadOnlyList<SpdxDiagnostic> diagnoastics)
    {
        // TODO: Build 
        throw new NotImplementedException();
    }
}
