namespace Spdx.Expressions;

/// <summary>
/// Represents a visitor for SPDX license expressions.
/// </summary>
/// <typeparam name="TContext">The context type.</typeparam>
public abstract class SpdxExpressionVisitor<TContext> : ISpdxExpressionVisitor<TContext, object?>
{
    /// <summary>
    /// Visits a <see cref="SpdxAndExpression"/> node.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="expression">The expression node.</param>
    protected void Visit(TContext context, SpdxExpression expression)
    {
        if (expression is null)
        {
            throw new ArgumentNullException(nameof(expression));
        }

        expression.Accept(context, this);
    }

    /// <inheritdoc/>
    object? ISpdxExpressionVisitor<TContext, object?>.VisitAnd(TContext context, SpdxAndExpression expression)
    {
        VisitAnd(context, expression);
        return null;
    }

    /// <inheritdoc/>
    object? ISpdxExpressionVisitor<TContext, object?>.VisitOr(TContext context, SpdxOrExpression expression)
    {
        VisitOr(context, expression);
        return null;
    }

    /// <inheritdoc/>
    object? ISpdxExpressionVisitor<TContext, object?>.VisitScope(TContext context, SpdxScopeExpression expression)
    {
        VisitScope(context, expression);
        return null;
    }

    /// <inheritdoc/>
    object? ISpdxExpressionVisitor<TContext, object?>.VisitWith(TContext context, SpdxWithExpression expression)
    {
        VisitWith(context, expression);
        return null;
    }

    /// <inheritdoc/>
    object? ISpdxExpressionVisitor<TContext, object?>.VisitLicense(TContext context, SpdxLicenseExpression expression)
    {
        VisitLicense(context, expression);
        return null;
    }

    /// <inheritdoc/>
    object? ISpdxExpressionVisitor<TContext, object?>.VisitException(TContext context, SpdxLicenseExceptionExpression expression)
    {
        VisitException(context, expression);
        return null;
    }

    /// <inheritdoc/>
    object? ISpdxExpressionVisitor<TContext, object?>.VisitReference(TContext context, SpdxLicenseReferenceExpression expression)
    {
        VisitReference(context, expression);
        return null;
    }

    /// <summary>
    /// Visits a <see cref="SpdxAndExpression"/> node.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="expression">The expression node.</param>
    public abstract void VisitAnd(TContext context, SpdxAndExpression expression);

    /// <summary>
    /// Visits a <see cref="SpdxOrExpression"/> node.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="expression">The expression node.</param>
    public abstract void VisitOr(TContext context, SpdxOrExpression expression);

    /// <summary>
    /// Visits a <see cref="SpdxScopeExpression"/> node.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="expression">The expression node.</param>
    public abstract void VisitScope(TContext context, SpdxScopeExpression expression);

    /// <summary>
    /// Visits a <see cref="SpdxWithExpression"/> node.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="expression">The expression node.</param>
    public abstract void VisitWith(TContext context, SpdxWithExpression expression);

    /// <summary>
    /// Visits a <see cref="SpdxLicenseExpression"/> node.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="expression">The expression node.</param>
    public abstract void VisitLicense(TContext context, SpdxLicenseExpression expression);

    /// <summary>
    /// Visits a <see cref="SpdxLicenseExceptionExpression"/> node.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="expression">The expression node.</param>
    public abstract void VisitException(TContext context, SpdxLicenseExceptionExpression expression);

    /// <summary>
    /// Visits a <see cref="SpdxLicenseReferenceExpression"/> node.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="expression">The expression node.</param>
    public abstract void VisitReference(TContext context, SpdxLicenseReferenceExpression expression);
}
