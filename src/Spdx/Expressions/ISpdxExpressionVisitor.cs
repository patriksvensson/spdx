namespace Spdx.Expressions;

/// <summary>
/// Represents a visitor for a SPDX license expression.
/// </summary>
/// <typeparam name="TContext">The context type.</typeparam>
/// <typeparam name="TResult">The result type.</typeparam>
public interface ISpdxExpressionVisitor<in TContext, out TResult>
{
    /// <summary>
    /// Visits a <see cref="SpdxAndExpression"/> node.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="expression">The expression node.</param>
    /// <returns>The result from the invocation.</returns>
    TResult VisitAnd(TContext context, SpdxAndExpression expression);

    /// <summary>
    /// Visits a <see cref="SpdxOrExpression"/> node.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="expression">The expression node.</param>
    /// <returns>The result from the invocation.</returns>
    TResult VisitOr(TContext context, SpdxOrExpression expression);

    /// <summary>
    /// Visits a <see cref="SpdxScopeExpression"/> node.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="expression">The expression node.</param>
    /// <returns>The result from the invocation.</returns>
    TResult VisitScope(TContext context, SpdxScopeExpression expression);

    /// <summary>
    /// Visits a <see cref="SpdxWithExpression"/> node.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="expression">The expression node.</param>
    /// <returns>The result from the invocation.</returns>
    TResult VisitWith(TContext context, SpdxWithExpression expression);

    /// <summary>
    /// Visits a <see cref="SpdxLicenseExpression"/> node.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="expression">The expression node.</param>
    /// <returns>The result from the invocation.</returns>
    TResult VisitLicense(TContext context, SpdxLicenseExpression expression);

    /// <summary>
    /// Visits a <see cref="SpdxLicenseExceptionExpression"/> node.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="expression">The expression node.</param>
    /// <returns>The result from the invocation.</returns>
    TResult VisitException(TContext context, SpdxLicenseExceptionExpression expression);

    /// <summary>
    /// Visits a <see cref="SpdxLicenseReferenceExpression"/> node.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="expression">The expression node.</param>
    /// <returns>The result from the invocation.</returns>
    TResult VisitReference(TContext context, SpdxLicenseReferenceExpression expression);
}
