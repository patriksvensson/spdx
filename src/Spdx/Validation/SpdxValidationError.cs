namespace Spdx.Validation;

public sealed class SpdxValidationError
{
    public string Message { get; }
    public Dictionary<string, string> Context { get; }

    public string? this[string key] => Context?[key];

    public SpdxValidationError(string message)
    {
        Message = message ?? throw new ArgumentNullException(nameof(message));
        Context = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
    }

    public SpdxValidationError WithInfo(string key, string? value)
    {
        if (!string.IsNullOrWhiteSpace(key))
        {
            Context[key] = value ?? string.Empty;
        }

        return this;
    }

    public SpdxValidationError WithInfoIfNotNull(string key, string? value)
    {
        if (!string.IsNullOrWhiteSpace(key) && value != null)
        {
            Context[key] = value ?? string.Empty;
        }

        return this;
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        builder.AppendLine(Message);

        foreach (var ctx in Context)
        {
            builder.Append(ctx.Key).Append('=').AppendLine(ctx.Value);
        }

        return builder.ToString();
    }
}
