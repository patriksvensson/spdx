namespace Spdx.Expressions;

/// <summary>
/// Represents a visitor for SPDX license expressions.
/// </summary>
/// <typeparam name="TContext">The context type.</typeparam>
/// <typeparam name="TResult">The result type.</typeparam>
public abstract class SpdxExpressionVisitor<TContext, TResult> : ISpdxExpressionVisitor<TContext, TResult>
{
    /// <summary>
    /// Visits the specified <see cref="SpdxExpression"/> node.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="expression">The expression node.</param>
    /// <returns>The result from the invocation.</returns>
    protected TResult Visit(TContext context, SpdxExpression expression)
    {
        if (expression is null)
        {
            throw new ArgumentNullException(nameof(expression));
        }

        return expression.Accept(context, this);
    }

    /// <inheritdoc/>
    public abstract TResult VisitAnd(TContext context, SpdxAndExpression expression);

    /// <inheritdoc/>
    public abstract TResult VisitOr(TContext context, SpdxOrExpression expression);

    /// <inheritdoc/>
    public abstract TResult VisitWith(TContext context, SpdxWithExpression expression);

    /// <inheritdoc/>
    public abstract TResult VisitScope(TContext context, SpdxScopeExpression expression);

    /// <inheritdoc/>
    public abstract TResult VisitLicense(TContext context, SpdxLicenseExpression expression);

    /// <inheritdoc/>
    public abstract TResult VisitException(TContext context, SpdxLicenseExceptionExpression expression);

    /// <inheritdoc/>
    public abstract TResult VisitReference(TContext context, SpdxLicenseReferenceExpression expression);
}
