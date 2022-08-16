namespace Spdx;

public sealed class SpdxDiagnostic
{
    public SpdxDiagnosticKind Kind { get; }
    public string Message { get; }
    public Dictionary<string, object> Context { get; }

    public SpdxDiagnostic(SpdxDiagnosticKind kind, string message)
    {
        Kind = kind;
        Message = message;
        Context = new Dictionary<string, object>();
    }

    public object? GetContext(string name)
    {
        Context.TryGetValue(name, out var value);
        return value;
    }

    public SpdxDiagnostic WithContext(string key, object value)
    {
        Context.Add(key, value);
        return this;
    }
}
