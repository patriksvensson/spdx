namespace Spdx.Internal;

internal sealed class SpdxBuilderContext
{
    public List<SpdxDiagnostic> Diagnostics { get; }
    public bool HasErrors => Diagnostics.Any(d => d.Kind == SpdxDiagnosticKind.Error);

    public SpdxBuilderContext()
    {
        Diagnostics = new List<SpdxDiagnostic>();
    }

    public SpdxBuilderContextScope CreateScope(string? name = null)
    {
        return new SpdxBuilderContextScope(this, name);
    }

    public void AddDiagnostic(SpdxDiagnostic diagnostic)
    {
        Diagnostics.Add(diagnostic);
    }
}
