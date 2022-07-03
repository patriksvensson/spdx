namespace Spdx.Expressions;

/// <summary>
/// Represents a <c>WITH</c> node in a SPDX license expression.
/// </summary>
public sealed class SpdxWithExpression : SpdxExpression
{
    /// <summary>
    /// Gets the expression node.
    /// </summary>
    public SpdxExpression Expression { get; }

    /// <summary>
    /// Gets the license exception node.
    /// </summary>
    public SpdxLicenseExceptionExpression Exception { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SpdxWithExpression"/> class.
    /// </summary>
    /// <param name="expression">The expression node.</param>
    /// <param name="exception">The license exception node.</param>
    public SpdxWithExpression(SpdxExpression expression, SpdxLicenseExceptionExpression exception)
    {
        Expression = expression ?? throw new ArgumentNullException(nameof(expression));
        Exception = exception ?? throw new ArgumentNullException(nameof(exception));
    }

    /// <inheritdoc/>
    public override TResult Accept<TContext, TResult>(TContext context, ISpdxExpressionVisitor<TContext, TResult> visitor)
    {
        return visitor.VisitWith(context, this);
    }
}
