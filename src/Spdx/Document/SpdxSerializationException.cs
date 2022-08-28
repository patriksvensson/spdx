namespace Spdx.Document;

/// <summary>
/// Represents an error that occured during serialization.
/// </summary>
public sealed class SpdxSerializationException : Exception
{
    /// <summary>
    /// Gets the validation report, if any.
    /// </summary>
    public SpdxValidationReport? Report { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SpdxSerializationException"/> class.
    /// </summary>
    /// <param name="message">The exception message.</param>
    /// <param name="report">The validation report.</param>
    public SpdxSerializationException(string? message, SpdxValidationReport report)
        : base(message)
    {
        Report = report;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SpdxSerializationException"/> class.
    /// </summary>
    /// <param name="message">The exception message.</param>
    /// <param name="innerException">The inner exception.</param>
    public SpdxSerializationException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }
}
