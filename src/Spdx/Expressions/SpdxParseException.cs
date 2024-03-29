namespace Spdx.Expressions;

/// <summary>
/// Represents errors that occur during SPDX expression parsing.
/// </summary>
public sealed class SpdxParseException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SpdxParseException"/> class.
    /// </summary>
    public SpdxParseException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SpdxParseException"/> class.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public SpdxParseException(string? message)
        : base(message)
    {
    }

#if !NET8_0_OR_GREATER
    /// <summary>
    /// Initializes a new instance of the <see cref="SpdxParseException"/> class.
    /// </summary>
    /// <param name="info">
    /// The <see cref="SerializationInfo"/> that holds the serialized
    /// object data about the exception being thrown.
    /// </param>
    /// <param name="context">
    /// The <see cref="StreamingContext"/> that contains contextual
    /// information about the source or destination.
    /// </param>
    public SpdxParseException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
#endif

    /// <summary>
    /// Initializes a new instance of the <see cref="SpdxParseException"/> class.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="innerException">
    /// The exception that is the cause of the current exception,
    /// or a null reference if no inner exception is specified.
    /// </param>
    public SpdxParseException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }
}
