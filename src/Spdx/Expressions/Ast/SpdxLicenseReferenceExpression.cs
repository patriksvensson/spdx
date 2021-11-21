namespace Spdx.Expressions.Ast;

/// <summary>
/// Represents a license reference node in a SPDX license expression.
/// </summary>
public sealed class SpdxLicenseReferenceExpression : SpdxExpression
{
    /// <summary>
    /// Gets the document reference (if any).
    /// </summary>
    public string DocumentReference { get; } = string.Empty;

    /// <summary>
    /// Gets the license reference.
    /// </summary>
    public string LicenseRef { get; } = string.Empty;

    /// <summary>
    /// Initializes a new instance of the <see cref="SpdxLicenseReferenceExpression"/> class.
    /// </summary>
    /// <param name="documentReference">The document reference.</param>
    /// <param name="licenseRef">The license reference.</param>
    public SpdxLicenseReferenceExpression(string? documentReference, string licenseRef)
    {
        DocumentReference = documentReference ?? string.Empty;
        LicenseRef = licenseRef;

        if (string.IsNullOrWhiteSpace(DocumentReference) &&
            string.IsNullOrWhiteSpace(LicenseRef))
        {
            throw new InvalidOperationException("Invalid SPDX license reference");
        }
    }

    internal override TResult Accept<TContext, TResult>(TContext context, ISpdxExpressionVisitor<TContext, TResult> visitor)
    {
        return visitor.VisitReference(context, this);
    }
}
