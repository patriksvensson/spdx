namespace Spdx.Validation;

public sealed class SpdxValidationReport
{
    private readonly List<SpdxValidationError> _errors;

    public bool Successful => Errors.Count == 0;
    public IReadOnlyList<SpdxValidationError> Errors => _errors;

    public SpdxValidationReport()
    {
        _errors = new List<SpdxValidationError>();
    }

    public SpdxValidationReport(IEnumerable<SpdxValidationError> errors)
    {
        _errors = new List<SpdxValidationError>(errors ?? Enumerable.Empty<SpdxValidationError>());
    }
}
