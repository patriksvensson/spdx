namespace Spdx.Document;

/// <summary>
/// Represents a SPDX validation report.
/// </summary>
public sealed class SpdxValidationReport
{
    private readonly List<SpdxValidationError> _errors;

    /// <summary>
    /// Gets a value indicating whether or not validation was successful.
    /// </summary>
    public bool Successful => Errors.Count == 0;

    /// <summary>
    /// Gets the list of validation errors.
    /// </summary>
    public IReadOnlyList<SpdxValidationError> Errors => _errors;

    /// <summary>
    /// Initializes a new instance of the <see cref="SpdxValidationReport"/> class.
    /// </summary>
    public SpdxValidationReport()
    {
        _errors = new List<SpdxValidationError>();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SpdxValidationReport"/> class.
    /// </summary>
    /// <param name="errors">The validation errors.</param>
    public SpdxValidationReport(IEnumerable<SpdxValidationError> errors)
    {
        _errors = new List<SpdxValidationError>(errors ?? Enumerable.Empty<SpdxValidationError>());
    }
}
