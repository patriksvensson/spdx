namespace Spdx.Expressions;

/// <summary>
/// Represents a unary scope in a SPDX license expression.
/// </summary>
public sealed class SpdxScopeExpression : SpdxExpression
{
    /// <summary>
    /// Gets the expression node.
    /// </summary>
    public SpdxExpression Expression { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SpdxScopeExpression"/> class.
    /// </summary>
    /// <param name="expression">The expression node.</param>
    public SpdxScopeExpression(SpdxExpression expression)
    {
        Expression = expression ?? throw new ArgumentNullException(nameof(expression));
    }

    /// <inheritdoc/>
    public override TResult Accept<TContext, TResult>(TContext context, ISpdxExpressionVisitor<TContext, TResult> visitor)
    {
        return visitor.VisitScope(context, this);
    }
}
