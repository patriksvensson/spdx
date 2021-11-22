namespace Spdx.Expressions.Ast;

/// <summary>
/// Represents a license ID node in a SPDX license expression.
/// </summary>
public sealed class SpdxLicenseExpression : SpdxExpression
{
    /// <summary>
    /// Gets the license ID.
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// Gets a value indicating whether or not later versions of the license is accepted.
    /// </summary>
    public bool OrLater { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SpdxLicenseExpression"/> class.
    /// </summary>
    /// <param name="id">The license ID.</param>
    /// <param name="orLater">A value indicating whether or not later versions of the license is accepted.</param>
    public SpdxLicenseExpression(string id, bool orLater)
    {
        Id = id ?? throw new ArgumentNullException(nameof(id));
        OrLater = orLater;
    }

    /// <inheritdoc/>
    public override TResult Accept<TContext, TResult>(TContext context, ISpdxExpressionVisitor<TContext, TResult> visitor)
    {
        return visitor.VisitLicense(context, this);
    }
}
