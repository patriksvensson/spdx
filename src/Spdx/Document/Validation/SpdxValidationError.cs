namespace Spdx.Document;

/// <summary>
/// Represents a SPDX validation error.
/// </summary>
public sealed class SpdxValidationError
{
    /// <summary>
    /// Gets the validation error message.
    /// </summary>
    public string Message { get; }

    /// <summary>
    /// Gets the validation context.
    /// </summary>
    public Dictionary<string, string> Context { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SpdxValidationError"/> class.
    /// </summary>
    /// <param name="message">The validation error message.</param>
    public SpdxValidationError(string message)
    {
        Message = message ?? throw new ArgumentNullException(nameof(message));
        Context = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
    }

    internal SpdxValidationError WithInfo<T>(string key, T? value)
    {
        if (!string.IsNullOrWhiteSpace(key))
        {
            Context[key] = value?.ToString() ?? string.Empty;
        }

        return this;
    }

    internal SpdxValidationError WithInfoIfNotNull<T>(string key, T? value)
    {
        if (!string.IsNullOrWhiteSpace(key) && value != null)
        {
            Context[key] = value.ToString() ?? string.Empty;
        }

        return this;
    }

    internal SpdxValidationError WithInfoIfNotNullOrEmpty(string key, string? value)
    {
        if (!string.IsNullOrWhiteSpace(key) && !string.IsNullOrWhiteSpace(value))
        {
            Context[key] = value ?? string.Empty;
        }

        return this;
    }
}
