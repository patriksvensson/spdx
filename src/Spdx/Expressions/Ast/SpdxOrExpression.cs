namespace Spdx.Expressions;

/// <summary>
/// Represents a <c>OR</c> node in a SPDX license expression.
/// </summary>
public sealed class SpdxOrExpression : SpdxExpression
{
    /// <summary>
    /// Gets the left side of the expression.
    /// </summary>
    public SpdxExpression Left { get; }

    /// <summary>
    /// Gets the right side of the expression.
    /// </summary>
    public SpdxExpression Right { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SpdxOrExpression"/> class.
    /// </summary>
    /// <param name="left">The left side of the expression.</param>
    /// <param name="right">The right side of the expression.</param>
    public SpdxOrExpression(SpdxExpression left, SpdxExpression right)
    {
        Left = left ?? throw new ArgumentNullException(nameof(left));
        Right = right ?? throw new ArgumentNullException(nameof(right));
    }

    /// <inheritdoc/>
    public override TResult Accept<TContext, TResult>(TContext context, ISpdxExpressionVisitor<TContext, TResult> visitor)
    {
        return visitor.VisitOr(context, this);
    }
}
