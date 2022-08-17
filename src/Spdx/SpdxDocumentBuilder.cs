using Spdx.Internal;

namespace Spdx;

public sealed class SpdxDocumentBuilder
{
    // Required
    private string? _identifier;
    private string? _name;
    private SpdxDocumentUri? _namespace;
    private SpdxCreationInfoBuilder? _creationInfoBuilder;

    // Optional
    private List<SpdxExternalDocumentRef> _externalDocumentRefs;
    private string? _comment;

    public SpdxDocumentBuilder()
    {
        _externalDocumentRefs = new List<SpdxExternalDocumentRef>();
    }

    public SpdxDocumentBuilder SetIdentifier(string identifier)
    {
        _identifier = identifier;
        return this;
    }

    public SpdxDocumentBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public SpdxDocumentBuilder SetNamespace(SpdxDocumentUri uri)
    {
        _namespace = uri;
        return this;
    }

    public SpdxDocumentBuilder SetCreationInfo(Action<SpdxCreationInfoBuilder> action)
    {
        _creationInfoBuilder = new SpdxCreationInfoBuilder();
        action(_creationInfoBuilder);
        return this;
    }

    public SpdxDocumentBuilder AddExternalDocument(SpdxExternalDocumentRef externalDocumentRef)
    {
        _externalDocumentRefs.Add(externalDocumentRef);
        return this;
    }

    public SpdxDocumentBuilder SetComment(string comment)
    {
        _comment = comment;
        return this;
    }

    public bool TryBuild(out IReadOnlyList<SpdxDiagnostic> diagnostics, out SpdxDocument? document)
    {
        var context = new SpdxBuilderContext();

        document = null;
        diagnostics = context.Diagnostics;

        using (var scope = context.CreateScope("Document"))
        {
            if (string.IsNullOrWhiteSpace(_identifier))
            {
                scope.AddError("Document identifier not set");
            }

            if (string.IsNullOrWhiteSpace(_name))
            {
                scope.AddError("Document name not set");
            }

            if (_namespace == null)
            {
                scope.AddError("Document namespace not set");
            }

            if (_creationInfoBuilder == null)
            {
                scope.AddError("Creation info not set");
            }

            var creationInfo = _creationInfoBuilder?.Build(context);

            if (!context.HasErrors)
            {
                document = new SpdxDocument(
                    _identifier!, _name!, _namespace!,
                    creationInfo!, _externalDocumentRefs, _comment);
            }

            return document != null;
        }
    }
}