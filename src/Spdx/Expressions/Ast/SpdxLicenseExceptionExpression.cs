namespace Spdx.Expressions;

/// <summary>
/// Represents a license exception ID node in a SPDX license expression.
/// </summary>
public sealed class SpdxLicenseExceptionExpression : SpdxExpression
{
    /// <summary>
    /// Gets the license exception ID.
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SpdxLicenseExceptionExpression"/> class.
    /// </summary>
    /// <param name="id">The license exception ID.</param>
    public SpdxLicenseExceptionExpression(string id)
    {
        Id = id ?? throw new ArgumentNullException(nameof(id));
    }

    /// <inheritdoc/>
    public override TResult Accept<TContext, TResult>(TContext context, ISpdxExpressionVisitor<TContext, TResult> visitor)
    {
        return visitor.VisitException(context, this);
    }
}
